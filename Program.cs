using LLama.Common;
using LLama;
// library docs https://github.com/SciSharp/LLamaSharp
// download models from https://huggingface.co/TheBloke/Llama-2-7b-Chat-GGUF/blob/main/llama-2-7b-chat.Q5_K_S.gguf
string modelPath = @"models\llama-2-7b-chat.Q5_K_S.gguf"; // change it to your own model path
var prompt = "Transcript of a dialog, where the User interacts with an Assistant named Bob. Bob is helpful, kind, honest, good at writing, and never fails to answer the User's requests immediately and with precision.\r\n\r\nUser: Hello, Bob.\r\nBob: Hello. How may I help you today?\r\nUser: Please tell me the largest city in Europe.\r\nBob: Sure. The largest city in Europe is Moscow, the capital of Russia.\r\nUser:"; // use the "chat-with-bob" prompt here.

// Load a model
var parameters = new ModelParams(modelPath)
{
    ContextSize = 8196,
    Seed = 1337,
    GpuLayerCount = 20,
};
using var model = LLamaWeights.LoadFromFile(parameters);

// Initialize a chat session
using var context = model.CreateContext(parameters);
var ex = new InteractiveExecutor(context);
ChatSession session = new ChatSession(ex);

// show the prompt
Console.WriteLine();
Console.Write(prompt);

// run the inference in a loop to chat with LLM
while (prompt != "stop")
{
    foreach (var text in session.Chat(prompt, new InferenceParams() { TopK = 20, TopP = 0.95f, Temperature = 0.0f, AntiPrompts = new List<string> { "User:" } }))
    {
        Console.Write(text);
    }
    prompt = Console.ReadLine() ?? "stop";
}

// save the session
session.SaveSession("SavedSessionPath");