namespace AppFullWebAPI.Models
{
    public static class CollegeRepository
    {
        public static List<Student> Students { get; set; } = new List<Student>
            {
                new Student{
                    Id = 1,
                    StudentName = "Carlos",
                    Address = "Ahuachapan, Colonia Santa Maria 2",
                    Email = "carlos@gmail.com"
                },
                new Student{
                    Id = 2,
                    StudentName = "Jose",
                    Address = "San Salvador, colonia Escalon",
                    Email = "jose@gmail.com"
                }
            };
    }
}
