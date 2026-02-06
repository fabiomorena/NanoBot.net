using System.Text.Json.Nodes;

namespace Nanobot.Core.Tools.Builtin;

public class EditFileTool : ITool
{
    public string Name => "edit_file";
    public string Description => "Replace a string in a file with another string.";

    public JsonNode Parameters => JsonNode.Parse("""
    {
        "type": "object",
        "properties": {
            "path": { "type": "string", "description": "The path to the file." },
            "old_string": { "type": "string", "description": "The string to find." },
            "new_string": { "type": "string", "description": "The string to replace it with." }
        },
        "required": ["path", "old_string", "new_string"]
    }
    """)!;

    public async Task<string> ExecuteAsync(JsonNode? arguments)
    {
        var path = arguments?["path"]?.ToString();
        var oldString = arguments?["old_string"]?.ToString();
        var newString = arguments?["new_string"]?.ToString();

        if (string.IsNullOrEmpty(path) || oldString == null || newString == null)
            return "Error: path, old_string, and new_string are required.";

        try
        {
            if (!File.Exists(path)) return $"Error: File '{path}' not found.";

            var content = await File.ReadAllTextAsync(path);
            if (!content.Contains(oldString)) return "Error: old_string not found in file.";

            var newContent = content.Replace(oldString, newString);
            await File.WriteAllTextAsync(path, newContent);
            return $"Successfully updated {path}.";
        }
        catch (Exception ex)
        {
            return $"Error editing file: {ex.Message}";
        }
    }
}
