using System.IO;
using System.Text.RegularExpressions;

var path = @"C:\Users\AIO\source\repos\Centraly.Api\Centraly.Api\Services\Implementation\DrawerService.cs";
var content = File.ReadAllText(path);

content = Regex.Replace(content, "public async Task<Result<DrawerSessionResponse>> GetActiveSessionAsync\\(CancellationToken", "public async Task<Result<DrawerSessionResponse>> GetActiveSessionAsync(int type = 1, CancellationToken");

content = Regex.Replace(content, "public async Task<Result<DrawerSessionResponse>> CloseSessionAsync\\(string userId, CancellationToken", "public async Task<Result<DrawerSessionResponse>> CloseSessionAsync(int type, string userId, CancellationToken");

content = Regex.Replace(content, @"s => !s\.IsClosed", @"s => !s.IsClosed && (int)s.Type == type");

content = Regex.Replace(content, @"AnyAsync\(s => !s\.IsClosed", @"AnyAsync(s => !s.IsClosed && (int)s.Type == request.Type");

content = Regex.Replace(content, @"var session = new DrawerSession\s*\{", "var session = new DrawerSession\n        {\n            Type = (DrawerType)request.Type,");

File.WriteAllText(path, content);
