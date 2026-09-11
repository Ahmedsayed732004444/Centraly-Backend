using System.IO;
using System.Text.RegularExpressions;

var path = @"C:\Users\AIO\source\repos\Centraly.Api\Centraly.Api\Services\Implementation\DrawerService.cs";
var content = File.ReadAllText(path);

// Fix OpenSessionAsync type variable
content = Regex.Replace(content, @"(public async Task<Result<DrawerSessionResponse>> OpenSessionAsync.*?\n\s*\{\n\s*var activeSession = await _dbContext\.DrawerSessions\.FirstOrDefaultAsync\(s => !s\.IsClosed && \(int\)s\.Type == )type", "$1request.Type");

// Fix RecordTransactionAsync type comparison
content = Regex.Replace(content, @"(public async Task<Result<DrawerTransactionResponse>> RecordTransactionAsync.*?\n\s*\{\n)(.*?\n.*?)&& \(int\)s\.Type == type", "$1        var targetDrawerType = category == DrawerTransactionCategory.Maintenance ? 2 : 1;\n$2&& (int)s.Type == targetDrawerType");

File.WriteAllText(path, content);