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
    public class OrderController : ControllerBase
    {
        public OrderController(IOrderRep orderRep,IMapper mapper)
        {
            OrderRep = orderRep;
            Mapper = mapper;
        }

        public IOrderRep OrderRep { get; }
        public IMapper Mapper { get; }

        [HttpGet]
        [Route("~/Api/GetProducts")]
        public IActionResult GetProducts()
        {
            try
            {
                var data = OrderRep.Get();

                var model = Mapper.Map<IEnumerable<OrderVM>>(data);

                return Ok(new ApiResponse<IEnumerable<OrderVM>>()
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
                var data = OrderRep.GetById(id);

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
                    var data = Mapper.Map<Order>(model);

                    var result = OrderRep.Create(data);

                    return Ok(new ApiResponse<Order>()
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
        public IActionResult PutProducts(OrderVM model)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    var data = Mapper.Map<Order>(model);

                    var result = OrderRep.Update(data);

                    return Ok(new ApiResponse<Order>()
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
        public IActionResult DeleteProducts(OrderVM model)
        {
            try
            {
                var data = Mapper.Map<Order>(model);

                OrderRep.Delete(data);

                return Ok(new ApiResponse<OrderVM>()
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
