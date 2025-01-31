using ConvertBlob.Context;
using ConvertBlob.InterFace;
using ConvertBlob.Models;

namespace ConvertBlob.Services
{
    public class BlobConverterService : IBlobConverter
    {
		private readonly AppDbContext _appDbContext;
        private readonly IConfiguration _configuration;
        private readonly IServiceScopeFactory _serviceScopeFactory;
        public BlobConverterService(AppDbContext appDbContext, IConfiguration configuration, IServiceScopeFactory serviceScopeFactory)
        {
            _appDbContext = appDbContext;
            _configuration = configuration;
            _serviceScopeFactory = serviceScopeFactory;
        }

        public async Task<string> ConvertBlob()
        {
			string message = string.Empty;
			try
            {
                using (var scope = _serviceScopeFactory.CreateScope())
                {
                    var targetDbContext = scope.ServiceProvider.GetRequiredService<TargetDbContext>();

                    var files = _appDbContext.fileDatas.ToList();
                    string filePath = _configuration.GetSection("FolderPath:blobImage").Value;

                    if (!Directory.Exists(filePath))
                    {
                        Directory.CreateDirectory(filePath);
                    }

                    foreach (var file in files)
                    {
                        FileData fileData = new FileData();
                        fileData.Id = file.Id;
                        fileData.Name = file.Name;
                        fileData.Bytes = file.Bytes;

                        await targetDbContext.fileData.AddAsync(fileData);
                    }

                    await targetDbContext.SaveChangesAsync();
                    message = "Files successfully transferred to target database.";
                }
            }
			catch (Exception e)
			{
				throw new Exception($"Error : {e.Message}");
			}
			return message;
        }
    }
}
