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
    public class StoreController : ControllerBase
    {
        public StoreController(IMapper mapper,IStoreRep storeRep)
        {
            Mapper = mapper;
            StoreRep = storeRep;
        }

        public IMapper Mapper { get; }
        public IStoreRep StoreRep { get; }
        

        [HttpGet]
        [Route("~/Api/GetStores")]
        public IActionResult GetStores()
        {
            try
            {
                var data = StoreRep.Get();

                var model = Mapper.Map<IEnumerable<StoreVM>>(data);

                return Ok(new ApiResponse<IEnumerable<StoreVM>>()
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
        [Route("~/Api/GetStoresById/{id}")]
        public IActionResult GetStoresById(int id)
        {
            try
            {
                var data = StoreRep.GetById(id);

                var model = Mapper.Map<StoreVM>(data);

                return Ok(new ApiResponse<StoreVM>()
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
        public IActionResult PostProducts(StoreVM model)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    var data = Mapper.Map<Stores>(model);

                    var result = StoreRep.Create(data);

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
        public IActionResult PutProducts(StoreVM model)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    var data = Mapper.Map<Products>(model);

                    var result = StoreRep.Update(data);

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
        public IActionResult DeleteProducts(StoreVM model)
        {
            try
            {
                var data = Mapper.Map<Stores>(model);

                StoreRep.Delete(data);

                return Ok(new ApiResponse<StoreVM>()
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
