using LSI.Application.Repositories.Interfaces;
using LSI.Common.Exceptions;
using LSI.Common.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace LSI.Controllers
{
    public class BaseActionDtoController<UDto> : Controller
        where UDto : BaseDto
    {
        private readonly ILogger _logger;
        public BaseActionDtoController(ILogger loger)
        {
            _logger = loger;
        }

        protected async Task<bool> RunActionNoResultAsync(Func<Task> func)
        {
            try
            {
                await func();
            }
            catch (ModelNotFoundException re)
            {
                return false;
            }
            catch (WrongParemetrsException ve)
            {
                return false;
            }
            catch (Exception ex)
            {
                await _logger.LogException(ex);
                return false;
            }

            return true;
        }

        protected async Task<Tuple<List<UDto>, int>> RunTupleResultAsync(Func<Task<Tuple<List<UDto>, int>>> func)
        {
            try
            {
                return await func();
            }
            catch (ModelNotFoundException re)
            {
                return null;
            }
            catch (WrongParemetrsException ve)
            {
                return null;
            }
            catch (Exception ex)
            {
                await _logger.LogException(ex);
            }

            return null;
        }

        protected async Task<List<AnyDto>> RunListActionResultAsync<AnyDto>(Func<Task<List<AnyDto>>> func)
        {
            try
            {
                return await func();
            }
            catch (ModelNotFoundException re)
            {
                return null;
            }
            catch (WrongParemetrsException ve)
            {
                return null;
            }
            catch (Exception ex)
            {
                await _logger.LogException(ex);
            }

            return null;
        }

        protected async Task<UDto> RunSingleActionResultAsync(Func<Task<UDto>> func)
        {
            try
            {
                return await func();
            }
            catch (ModelNotFoundException re)
            {
                return default(UDto);
            }
            catch (WrongParemetrsException ve)
            {
                return default(UDto);
            }
            catch (Exception ex)
            {
                await _logger.LogException(ex);
            }

            return default(UDto);
        }

    }
}