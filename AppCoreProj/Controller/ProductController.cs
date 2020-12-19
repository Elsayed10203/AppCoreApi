using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Contracts;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Repository;

namespace AppCoreProj.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private ILoggerManager Log;

         private IRepositoryBase<Product> Repo;
        //  private IRepositoryManger Repo;

        //public ProductController(IRepositoryManger _Repo, ILoggerManager Ilogger)
        public ProductController(IRepositoryBase<Product> _Repo, ILoggerManager Ilogger)
        {
            Repo = _Repo;
             Log = Ilogger;
        }


        public IActionResult GetAllProduct()
         {
            try
            {
                //return Ok(Repo.products.GetproductAsyn(false));
                return Ok(Repo.FindAll(false));
            }
            catch (Exception ex)
            {
                Log.LogError($"Action is : {nameof(GetAllProduct)}  Error is  {ex.Message}");
                return StatusCode(500, " Internal Server Error");
             }
        }


       [HttpPost]
        public IActionResult AddProduct( )
        {
            try
            {
                var ObjJson = Request.Form["product"];
                Product Prod = JsonConvert.DeserializeObject<Product>(ObjJson);

                if (Prod == null)
                {
                    Log.LogWarn($"the data is not in correct product Format{Prod}");
                    return BadRequest();
                }
               /*   
                if (Repo.FindByCondition(x => x.Id == Prod.Id, false).FirstOrDefault() != null)
                {
                    Log.LogInfo($"The Code Is Not Unique{Prod.Id}");
                    return Content("the product Code Isnot Unique");
                }*/
                Repo.Create(Prod);
                Prod.lastupdate = DateTime.Now.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss");
                Repo.SaveChanges();
                Prod.Photo = saveFile(Prod);
                return Created("Success", Prod);
                 
            }
            catch (Exception ex)
            {
                Log.LogError($"Action is : {nameof(AddProduct)}  Error is  {ex.Message}");
                return StatusCode(500, " Internal Server Error");
            }

          
        }

       
        [HttpDelete("{id}")]
        public IActionResult DeleteProdut(int? id)
        {
            try
            {
                if (id != null)
                {
                    Product prod = Repo.FindByCondition(x => x.Id == id, false).SingleOrDefault();
                    if(prod==null)
                    {
                        Log.LogWarn($"Action is : {nameof(DeleteProdut)}  Warn is  {id} is not found");
                        return NotFound();
                    }
                    DeletProductPic(prod);
                    Repo.Delete(prod);
                    Repo.SaveChanges();
                    return Ok(Repo.FindAll(false));
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                Log.LogError($"Action is : {nameof(DeleteProdut)}  Error is  {ex.Message}");
                return StatusCode(500, " Internal Server Error");
            }

        }

        [HttpGet("{id}")]
        public IActionResult GetProduct(int ?id)
        {
            try
            {
                if (id != null)
                {
                    //  Log.LogInfo($"logger info {id}");
                    return Ok(Repo.FindByCondition(x => x.Id == id, false).SingleOrDefault());
                }
                Log.LogError($"the id is Not Found here {id}");
                return Content("The id is not Valid ");
            }
            catch (Exception ex)
            {
                Log.LogError($"Action is : {nameof(GetProduct)}  Error is  {ex.Message}");
                return StatusCode(500, " Internal Server Error");
            }
        }

        [HttpPut]
        public IActionResult UpdateProduct( )
        {
            try
            {
                var ObjJson = Request.Form["product"];
                Product Prod = JsonConvert.DeserializeObject<Product>(ObjJson);

                if (Prod==null)
                {
                    Log.LogWarn($"Action is : {nameof(UpdateProduct)}   Warning Prod is Not in correct format");                 
                    return BadRequest("the prod is null");
                }
                saveFile(Prod);

                Repo.Update(Prod);
                Prod.lastupdate = DateTime.Now.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss");

                 return Ok(Prod);
            }
            catch (Exception ex)
            {
                Log.LogError($"Action is : {nameof(UpdateProduct)}  Error is  {ex.Message}");
                return StatusCode(500, " Internal Server Error");
            }
        }



        //Save File
        string saveFile(Product Prod)
        {
                 var postedFile = Request.Form.Files["Image"];
                string ImageExtension, ImagePath = "";
                string path = "";

                if (postedFile != null)
                {
                    DeletProductPic(Prod);
                    ImageExtension = Path.GetExtension(postedFile.FileName);
                    ImagePath = Directory.GetCurrentDirectory();
                    ImagePath = Path.Combine(ImagePath, "Resources", $"{Prod.Id}{ImageExtension}");
                    FileStream fs = new FileStream(ImagePath, FileMode.Create);
                    postedFile.CopyTo(fs);
                    fs.Close();
                    path = Prod.Id + "" + ImageExtension;
                }
                return path;
           
        }

        void DeletProductPic(Product Prod)
        {
            if (Prod.Photo != string.Empty)
            {
                try
                {
                    string Root_Path = Directory.GetCurrentDirectory();
                    string FullPath = Path.Combine(Root_Path, "Resources",Prod.Photo);

                    System.IO.File.Delete(FullPath);
                }
                catch (Exception ex)
                {

                    Log.LogError($"Function is : Delete Picture  Error is  {ex.Message}");
                }

            }
        }


    }
}