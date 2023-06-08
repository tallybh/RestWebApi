using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RestWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DirectoryController : ControllerBase
    {
        public DirectoryController(ITransientService transientService)
        {
            int i = 1;
        }

        [HttpGet]
        [Route("DirectoryNames")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string[]))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public  async Task<IActionResult> GetDirectories(string directory)
        {
            await Task.Delay(500);
            if (!Directory.Exists(directory)) {
                return NotFound();
            }
            return Ok(Directory.GetDirectories(directory));
        }

        [HttpGet]
        [Route("GetFiles")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<MyFile>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetFiles(string directory)
        {
            
            if (!Directory.Exists(directory))
            {
                return NotFound();
            }

            var filesPathes = Directory.GetFiles(directory);

            List<MyFile> files = new List<MyFile>();
            foreach (var file in filesPathes)
            {
                FileInfo fileInfo = new FileInfo(file);
                files.Add(new MyFile
                {
                    Name = fileInfo.Name,
                    Extention = fileInfo.Extension,
                    Size = fileInfo.Length,
                    UpdateDate = fileInfo.LastWriteTime
                });
            }

            return Ok(files);
        }

        
        [HttpDelete]
        [Route("DeleteFile")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeleteFile(string fileName)
        {
            if (!System.IO.File.Exists(fileName))
            {
                return NotFound();
            }

            System.IO.File.Delete(fileName);
            return Ok();
        }
        // GET api/<DirectoryController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/<DirectoryController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<DirectoryController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<DirectoryController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
