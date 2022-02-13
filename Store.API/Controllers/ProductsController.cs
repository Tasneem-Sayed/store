using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Store.BL.Interface;
using Store.BL.Models;
using Store.DAL;
using Store.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        public ProductsController(IProductsRep productsRep,IMapper mapper)
        {
            ProductsRep = productsRep;
            Mapper = mapper;
        }

        public IProductsRep ProductsRep { get; }
        public IMapper Mapper { get; }
        [HttpGet]
        [Route("~/Api/GetProducts")]
        public IActionResult GetProducts()
        {
            try
            {
                var data = ProductsRep.Get();

                var model = Mapper.Map<IEnumerable<ProductsVM>>(data);

                return Ok(new ApiResponse<IEnumerable<ProductsVM>>()
                {
                    Code = "200",
                    Status = "Ok",
                    Message = "Data Retrieved",
                    Data = model
                });
            }
            catch (Exception ex)
            {
                return NotFound(new ApiResponse<string>()
                {
                    Code = "404",
                    Status = "Not Found",
                    Message = "Data Not Found",
                    Error = ex.Message
                });
            }
        }

        [HttpGet]
        [Route("~/Api/GetProductsById/{id}")]
        public IActionResult GetProductsById(int id)
        {
            try
            {
                var data = ProductsRep.GetById(id);

                var model = Mapper.Map<ProductsVM>(data);

                return Ok(new ApiResponse<ProductsVM>()
                {
                    Code = "200",
                    Status = "Ok",
                    Message = "Data Retrieved",
                    Data = model
                });
            }
            catch (Exception ex)
            {
                return NotFound(new ApiResponse<string>()
                {
                    Code = "404",
                    Status = "Not Found",
                    Message = "Data Not Found",
                    Error = ex.Message
                });
            }
        }
        [HttpPost]
        [Route("~/Api/PostProducts")]
        public IActionResult PostProducts(ProductsVM model)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    var data = Mapper.Map<Products>(model);

                    var result = ProductsRep.Create(data);

                    return Ok(new ApiResponse<Products>()
                    {
                        Code = "201",
                        Status = "Created",
                        Message = "Data Saved",
                        Data = result
                    });
                }

                return Ok(new ApiResponse<string>()
                {
                    Code = "400",
                    Status = "Not Valied",
                    Message = "Data Invalid"
                });

            }
            catch (Exception ex)
            {
                return NotFound(new ApiResponse<string>()
                {
                    Code = "404",
                    Status = "Faild",
                    Message = "Not Created",
                    Error = ex.Message
                });
            }
        }


        [HttpPut]
        [Route("~/Api/PutProducts")]
        public IActionResult PutProducts(ProductsVM model)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    var data = Mapper.Map<Products>(model);

                    var result = ProductsRep.Edit(data);

                    return Ok(new ApiResponse<Products>()
                    {
                        Code = "200",
                        Status = "Ok",
                        Message = "Data Updated",
                        Data = result
                    });
                }

                return Ok(new ApiResponse<string>()
                {
                    Code = "400",
                    Status = "Not Valied",
                    Message = "Data Invalid"
                });

            }
            catch (Exception ex)
            {
                return NotFound(new ApiResponse<string>()
                {
                    Code = "404",
                    Status = "Faild",
                    Message = "Not Created",
                    Error = ex.Message
                });
            }
        }



        [HttpDelete]
        [Route("~/Api/DeleteProducts")]
        public IActionResult DeleteProducts(ProductsVM model)
        {
            try
            {
                var data = Mapper.Map<Products>(model);

                ProductsRep.Delete(data);

                return Ok(new ApiResponse<ProductsVM>()
                {
                    Code = "200",
                    Status = "Ok",
                    Message = "Data Deleted",
                    Data = model
                });
            }
            catch (Exception ex)
            {
                return NotFound(new ApiResponse<string>()
                {
                    Code = "404",
                    Status = "Faild",
                    Message = "Not Created",
                    Error = ex.Message
                });
            }
        }

    }
}
