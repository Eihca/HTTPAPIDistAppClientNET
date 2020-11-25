namespace HttpAPIDistAppClientNET
{

    class News
    {

        public string Title { get; set; }
        public string Date { get; set; }
        public string Company { get; set; }
        public string Link { get; set; }
        public string Content { get; set; }

        public override string ToString()
        {
            return $"Title: {Title} \n" +
                $"Company: {Company} \n" +
                $"Date: {Date} \n" +
                $"Link: {Link} \n" +
                $"Content: {Content}\n_______________________________________";
        }
    }
}
