# LLM in dotnet

Just a project that implements the "chat" example from [SciSharp/LLamaSharp](https://github.com/SciSharp/LLamaSharp)

Since 0.5.1 `GGUF` format models are required, not `GGML`.

e.g. [TheBloke/Llama-2-7b-Chat-GGUF](https://huggingface.co/TheBloke/Llama-2-7b-Chat-GGUF)

## GPU / CUDA

Requires a GPU with enough RAM and CUDA support

1. [Install the CUDA toolkit](https://developer.nvidia.com/cuda-toolkit)

1. Comment out the CPU backend package (`LLamaSharp.Backend.Cpu`) in the `.csproj`
