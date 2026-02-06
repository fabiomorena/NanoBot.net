using System.Text.Json.Nodes;

namespace Nanobot.Core.Tools.Builtin;

public class ListDirTool : ITool
{
    public string Name => "list_dir";
    public string Description => "List files and directories in a given path.";

    public JsonNode Parameters => JsonNode.Parse("""
    {
        "type": "object",
        "properties": {
            "path": {
                "type": "string",
                "description": "The path to list. Defaults to current directory if empty."
            }
        }
    }
    """)!;

    public async Task<string> ExecuteAsync(JsonNode? arguments)
    {
        var path = arguments?["path"]?.ToString();
        if (string.IsNullOrEmpty(path))
        {
            path = Directory.GetCurrentDirectory();
        }

        try
        {
            if (!Directory.Exists(path))
            {
                return $"Error: Directory '{path}' does not exist.";
            }

            var dirs = Directory.GetDirectories(path);
            var files = Directory.GetFiles(path);

            var result = new List<string> { $"Contents of {path}:" };
            
            int count = 0;
            const int maxToDisplay = 100;

            foreach (var d in dirs)
            {
                if (count++ >= maxToDisplay) break;
                result.Add($"[DIR]  {Path.GetFileName(d)}");
            }
            
            foreach (var f in files)
            {
                if (count++ >= maxToDisplay) break;
                result.Add($"[FILE] {Path.GetFileName(f)}");
            }

            if (dirs.Length + files.Length > maxToDisplay)
            {
                result.Add($"... and {dirs.Length + files.Length - maxToDisplay} more items.");
            }

            return result.Count == 1 ? "Directory is empty." : string.Join("\n", result);
        }
        catch (Exception ex)
        {
            return $"Error listing directory: {ex.Message}";
        }
    }
}