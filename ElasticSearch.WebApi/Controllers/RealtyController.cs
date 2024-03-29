﻿using ElasticSearch.Domain.Classes;
using ElasticSearch.Domain.IApplicationService;
using ElasticSearch.Domain.Utilities;
using Microsoft.AspNetCore.Mvc;
using NLog;
using System;
using System.Net;
using System.Threading.Tasks;

namespace ElasticSearch.WebApi.Controllers
{
    public class RealtyController : Controller
    {
        private readonly IRealtyApplicationService realtyApplication;
        private readonly ISearchApplicationService search;
        private readonly Logger logger = LogManager.GetCurrentClassLogger();
        public RealtyController(IRealtyApplicationService realtyApplication,
                                ISearchApplicationService search)
        {
            this.realtyApplication = realtyApplication;
            this.search = search;
        }

        [HttpGet, Route("api/v1/Realty/ReIndex")]
        [ApiExplorerSettings(GroupName = "v1")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> ReIndex()
        {
            try
            {
                await realtyApplication.ReIndex();
                return Ok();
            }
            catch (Exception ex)
            {
                logger.Error($"Product/Search::{ex.Message}::{ex.InnerException}::{ex.StackTrace}::{ex.Data}");
                return StatusCode((int)HttpStatusCode.ExpectationFailed, ExceptionErrors.Extract(ex));
            }
        }

        [HttpPost, Route("api/v1/Realty")]
        [ApiExplorerSettings(GroupName = "v1")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> PostAttrib([FromBody]PagedRealtyFilter attributes)
        {
            try
            {
                return Ok(await realtyApplication.GetbyAttrib(attributes));
            }
            catch (Exception ex)
            {
                logger.Error($"Realty/PostAttrib::{ex.Message}::{ex.InnerException}::{ex.StackTrace}::{ex.Data}");
                return StatusCode((int)HttpStatusCode.ExpectationFailed, ExceptionErrors.Extract(ex));
            }
        }

        [HttpGet, Route("api/v1/Realty/GetById")]
        [ApiExplorerSettings(GroupName = "v1")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetById([FromQuery]string id)
        {
            try
            {
                return Ok(await search.FindById(id));
            }
            catch (Exception ex)
            {
                logger.Error($"Realty/PostAttrib::{ex.Message}::{ex.InnerException}::{ex.StackTrace}::{ex.Data}");
                return StatusCode((int)HttpStatusCode.ExpectationFailed, ExceptionErrors.Extract(ex));
            }
        }

        [HttpGet, Route("api/v1/Realty/GetAll")]
        [ApiExplorerSettings(GroupName = "v1")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await search.All());
            }
            catch (Exception ex)
            {
                logger.Error($"Realty/All::{ex.Message}::{ex.InnerException}::{ex.StackTrace}::{ex.Data}");
                return StatusCode((int)HttpStatusCode.ExpectationFailed, ExceptionErrors.Extract(ex));
            }
        }
    }
}
