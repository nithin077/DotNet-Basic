namespace Product.Models
{
    public static class CollegeRepository
    {
        public static List<Student> Student { get; set; } = new List<Student>() {
                new Student
                {
                    id = 1,
                    name ="Chilumula Nithin",
                    age = 24,
                    email = "nithin@gmail.com"
                },
                 new Student {
                    id = 2,
                    name ="Chilumula",
                    age = 24,
                    email = "chilumula@gmail.com"
                }
            };
    }
}
