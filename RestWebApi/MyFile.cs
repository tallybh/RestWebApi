namespace RestWebApi
{
    public record MyFile
    {
        public string Name { get; init; }
        public string Extention { get; init; }

        public long Size { get; init; }

        public DateTime UpdateDate { get; init; }

    }
}
