using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Store.BL.Interface;
using Store.BL.Models;
using Store.DAL.Entity;
using Store.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsOrder : ControllerBase
    {
        private readonly IProductOrderRep productsOrderrep;

        public ProductsOrder(IProductOrderRep productsOrderrep, IMapper mapper)
        {
            this.productsOrderrep = productsOrderrep;
            Mapper = mapper;
        }




        public IMapper Mapper { get; }
        

        [HttpGet]
        [Route("~/Api/GetProductsOrder")]
        public IActionResult GetProductsOrder()
        {
            try
            {
                var data = productsOrderrep.Get();

                var model = Mapper.Map<IEnumerable<ProductOrderVM>>(data);

                return Ok(new ApiResponse<IEnumerable<ProductOrderVM>>()
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
        [Route("~/Api/GetPostProductsOrderById/{id}")]
        public IActionResult GetPostProductsOrderById(int id)
        {
            try
            {
                var data = productsOrderrep.GetById(id);

                var model = Mapper.Map<ProductOrderVM>(data);

                return Ok(new ApiResponse<ProductOrderVM>()
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
        [Route("~/Api/PostProductsOrder")]
        public IActionResult PostProductsOrder(ProductOrderVM model)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    var data = Mapper.Map<ProductsOrder>(model);

                    var result = productsOrderrep.Create(data);

                    return Ok(new ApiResponse<ProductsOrder>()
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
        [Route("~/Api/PutProductsOrder")]
        public IActionResult PutProductsOrder(ProductOrderVM model)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    var data = Mapper.Map<ProductsOrder>(model);

                    var result = productsOrderrep.Edit(data);

                    return Ok(new ApiResponse<ProductsOrder>()
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
        [Route("~/Api/DeleteProductsOrder")]
        public IActionResult DeleteProductsOrder(ProductOrderVM model)
        {
            try
            {
                var data = Mapper.Map<ProductsOrder>(model);

                productsOrderrep.Delete(data);

                return Ok(new ApiResponse<ProductOrderVM>()
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
