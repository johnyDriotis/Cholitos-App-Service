namespace AppFullWebAPI.Models
{
    public static class CollegeRepository
    {
        public static List<Student> Students { get; set; } = new List<Student>
            {
                new Student{
                    Id = 1,
                    StudentName = "Nombre de estudiante #1",
                    Address = "Direccion estudiante #1",
                    Email = "studiante1@gmail.com"
                },
                new Student{
                    Id = 2,
                    StudentName = "Nombre de estudiante #2",
                    Address = "Direccion estudiante #2",
                    Email = "studiante2@gmail.com"
                }
            };
    }
}
