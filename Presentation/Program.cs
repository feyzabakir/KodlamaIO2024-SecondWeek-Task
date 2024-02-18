using Business.Abstracts;
using Business.Concrete;
using DataAccess.Concrete;
using Entities.Concrete;

IGenericService<Category> _categoryService = new GenericService<Category>(new CategoryDal());
IGenericService<Course> _courseService = new GenericService<Course>(new CourseDal());
IGenericService<Instructor> _instructorService = new GenericService<Instructor>(new InstructorDal());

// Category CRUD işlemler

Category category3 = new Category { Id = 3, Name = "Yapay Zeka" };
Category category4 = new Category { Id = 4, Name = "Web Geliştirme" };
Category category5 = new Category { Id = 5, Name = "Mobil Geliştirme" };

// Yeni kategori ekleme
await _categoryService.AddAsync(category3);
await _categoryService.AddAsync(category4);
await _categoryService.AddAsync(category5);

//// Katgori güncelleme

category4.Name = "Görüntü İşleme";   
await _categoryService.UpdateAsync(category4);

//Kategori silme

await _categoryService.RemoveAsync(await _categoryService.GetByIdAsync(1)); 

foreach (var category in await _categoryService.GetAllAsync())
{
    Console.WriteLine($"{category.Id}: {category.Name}");
}

Console.WriteLine("\n****************************\n");

// Course CRUD işlemleri

Course course3 = new Course
{
    Id = 1,
    Title = "Yazılım Geliştirici Yetiştirme Kampı (JAVA + REACT)",
    Description = "Başlangıç Seviye",
    Price = 200,
    CompletionRate = 90,
    CategoryId = 1, 
    InstructorId = 1 
};

Course course4 = new Course
{
    Id = 1,
    Title = "Yazılım Geliştirici Yetiştirme Kampı (JavaScript)",
    Description = "Javascript",
    Price = 200,
    CompletionRate = 90,
    CategoryId = 1, 
    InstructorId = 1 
};

// Yeni kurs ekleme
await _courseService.AddAsync(course3);
await _courseService.AddAsync(course4);

// Kurs güncelleme
course4.Description = "Advanced";
await _courseService.UpdateAsync(course4);

// Kurs silme
await _courseService.RemoveAsync(await _courseService.GetByIdAsync(2));

// Tüm kursları listeleme
foreach (var course in await _courseService.GetAllAsync())
{
    Console.WriteLine($"{course.Id}: {course.Title} - {course.Description} - {course.Price}");
}

Console.WriteLine("\n****************************\n");

// Instructor CRUD işlemleri

Instructor instructor3 = new Instructor
{
    Id = 1,
    FullName = "Nisa Nur Bakır",
    Email = "nisa@gmail.com",
    ImageUrl = "image.jpg"
};

Instructor instructor4 = new Instructor
{
    Id = 1,
    FullName = "Ali Yıldız",
    Email = "ali@gmail.com",
    ImageUrl = "imageAli.jpg"
};

// instructor ekleme
await _instructorService.AddAsync(instructor3);

// Instructor'ın email adresini güncelleme
instructor3.Email = "nisa_nur@gmail.com";
await _instructorService.UpdateAsync(instructor3);

// İnstructor'ı silmek
await _instructorService.RemoveAsync(await _instructorService.GetByIdAsync(1));

// Tüm instructorları listeleme
foreach (var instructor in await _instructorService.GetAllAsync())
{
    Console.WriteLine($"ID: {instructor.Id}, Full Name: {instructor.FullName}, Email: {instructor.Email}");
}