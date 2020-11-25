    using namespace HttpAPIDistAppClient{
    
    class News
    {

        public string Title { get; set; }
        public string Date { get; set; }
        public string Company { get; set; }
        public string Link { get; set; }
        public string Content { get; set; }

        public override string ToString()
        {
            return $"{Title}: {Link}";
        }
    }
    }