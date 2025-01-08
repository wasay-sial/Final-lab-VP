namespace Q2
{
    public class Product
    {
        private string name;
        private int price;
        private string category;


        public Product(string name, int price, string category)
        {
            this.name = name;
            this.price = price;
            this.category = category;
        }
        public void setName(string name)
        {
            this.name = name;
        }

        public void setPrice(int price)
        {
            this.price = price;
        }

        public void setCategorty(string cat)
        {
            category= cat;
        }
        public string getName()
        {
            return name;
        }

        public int getPrice()
        {
           return price;
        }

        public string getCategory()
        {
            return category;
        }
    }
}
