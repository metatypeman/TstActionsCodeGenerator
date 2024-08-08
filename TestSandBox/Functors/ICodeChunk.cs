namespace TestSandBox.Functors
{
    public interface ICodeChunk
    {
        void AddChild(ICodeChunk child);

        void Run();

        bool IsFinished { get; }
    }
}
