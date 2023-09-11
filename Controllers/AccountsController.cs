using Microsoft.AspNetCore.Mvc;
public class AccountsController : ControllerBase
{
private readonly DbHelper _db;

public AccountsController(EF_DataContext eF_DataContext) {
            _db = new DbHelper(eF_DataContext);
        }
        [HttpGet("Accounts")]
        public IActionResult GetAccount()
        {
            ResponseType type = ResponseType.Success;
                try 
                    {
                        IEnumerable < AccountModel > data = _db.GetAccounts();
                        if (!data.Any()) 
                        {
                            type = ResponseType.NotFound;
                        }
                        return Ok(ResponseHandler.GetAppResponse(type, data));
                    } 
                catch (Exception ex) 
                    {
                        return BadRequest(ResponseHandler.GetExceptionResponse(ex));
                    }
    }
        [HttpPost]
        [Route("Register")]
        public IActionResult Post([FromBody] AccountModel model)
         {
            
            try 
            {
                ResponseType type = ResponseType.Success;
                _db.SaveAccount(model);
                return Ok(ResponseHandler.GetAppResponse(type, model));
            } 
            catch (Exception ex) 
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }
        [HttpGet]
        [Route("api/[controller]/GetAccountByMail{email},{password}")]
        public IActionResult Get(string email,string password) 
        {
            ResponseType type = ResponseType.Success;
            try 
            {
                AccountModel data = _db.GetAccountByEmail(email,password);
                if (data == null) {
                    type = ResponseType.NotFound;
                }
                return Ok(ResponseHandler.GetAppResponse(type, data));
            }
            catch (Exception ex) 
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
            
        }
       
        [HttpDelete]
        [Route("api/[controller]/DeleteAccount/{email},{password}")]
        public IActionResult Delete(string email,string password) 
        {
            try 
            {
                ResponseType type = ResponseType.Success;
                _db.DeleteAccount(email,password);
                return Ok(ResponseHandler.GetAppResponse(type, "Delete Successfully"));
            }
            catch (Exception ex) 
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
            
        }



}