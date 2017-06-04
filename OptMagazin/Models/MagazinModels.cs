using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OptMagazin.Models
{
    public class MagazinModels
    {
    }

    // Пол
    public enum Gender
    {
        Male,
        Female
    }

    // Сотрудник
    public class Worker
    {
        [Display(Name = "Номер сотрудника")]
        public int WorkerId { get; set; }
        [Display(Name = "ФИО")]
        public string WorkerName { get; set; }
        [Display(Name = "Пол")]
        public Gender WorkerGender { get; set; }
        [Display(Name = "Дата рождения")]
        public DateTime WorkerBirthday { get; set; }
        [Display(Name = "Семейное положение")]
        public string FamilyStatus { get; set; }
        [Display(Name = "Телефон")]
        public string WorkerTelephone { get; set; }
        [Display(Name = "Почта")]
        [DataType(DataType.EmailAddress)]
        public string WorkerEmail { get; set; }
        [Display(Name = "Серия паспорта")]
        public int PassportSeries { get; set; }
        [Display(Name = "Номер паспорта")]
        public int PassportNumber { get; set; }
        [Display(Name = "ИНН")]
        public int Inn { get; set; }
    }

    // Ребенок сотрудника
    public class WorkerChild
    {
        public int WorkerChildId { get; set; }
        [Display(Name = "Сотрудник")]
        public int WorkerId { get; set; }
        public Worker Worker { get; set; }
        [Display(Name = "Имя")]
        public string ChildName { get; set; }
        [Display(Name = "Пол")]
        public Gender ChildGender { get; set; }
        [Display(Name = "Дата рождения")]
        public DateTime ChildBirthday { get; set; }
        [Display(Name = "Место обучения")]
        public string StudyPlace { get; set; }
    }

    // Отпуск
    public class Vacation
    {
        [Display(Name = "Номер отпуска")]
        public int VacationId { get; set; }
        [Display(Name = "Сотрудник")]
        public int WorkerId { get; set; }
        public Worker Worker { get; set; }
        [Display(Name = "Начало отпуска")]
        public DateTime VacationStart { get; set; }
        [Display(Name = "Конец отпуска")]
        public DateTime VacationEnd { get; set; }
        [Display(Name = "Вид отпуска")]
        public int VacationSortId { get; set; }
        public VacationSort VacationSort { get; set; }
        [Display(Name = "Статус отпуска")]
        public string VacationStatus { get; set; }
    }

    // Вид отпуска
    public class VacationSort
    {
        [Display(Name = "Номер вида отпуска")]
        public int VacationSortId { get; set; }
        [Display(Name = "Вид отпуска")]
        public string VacationName { get; set; }
    }

    // Образование сотрудника
    public class WorkerEducation
    {
        [Display(Name = "Номер")]
        public int WorkerEducationId { get; set; }
        [Display(Name = "Сотрудник")]
        public int WorkerId { get; set; }
        public Worker Worker { get; set; }
        [Display(Name = "Место обучения")]
        public int UniversityId { get; set; }
        public University University { get; set; }
        [Display(Name = "Начало обучения")]
        public DateTime EducationStart { get; set; }
        [Display(Name = "Окончания обучения")]
        public DateTime EducationEnd { get; set; }
        [Display(Name = "Специальность")]
        public int EducationSpecialtyId { get; set; }
        public EducationSpecialty EducationSpecialty { get; set; }

    }

    // Место учебы
    public class University
    {
        [Display(Name = "Номер")]
        public int UniversityId { get; set; }
        [Display(Name = "Название университета")]
        public string UniversityName { get; set; }
    }

    // Специальность
    public class EducationSpecialty
    {
        [Display(Name = "Номер")]
        public int EducationSpecialtyId { get; set; }
        [Display(Name = "Название специальности")]
        public string EducationSpecialtyName { get; set; }
    }

    // Должность
    public class WorkerPost
    {
        [Display(Name = "Номер")]
        public int WorkerPostId { get; set; }
        [Display(Name = "Должность")]
        public int PostId { get; set; }
        public Post Post { get; set; }
        public int WorkerId { get; set; }
        [Display(Name = "Сотрудник")]
        public Worker Worker { get; set; }
    }

    // Вид должности
    public class Post
    {
        [Display(Name = "Номер")]
        public int PostId { get; set; }
        [Display(Name = "Название должности")]
        public string PostName { get; set; }
    }

    // Премия
    public class WorkerPrize
    {
        [Display(Name = "Номер")]
        public int WorkerPrizeId { get; set; }
        [Display(Name = "Сотрудник")]
        public int WorkerId { get; set; }
        public Worker Worker { get; set; }
        [Display(Name = "Дата премии")]
        public DateTime PrizeDate { get; set; }
        [Display(Name = "Вид премии")]
        public int PrizeId { get; set; }
        public Prize Prize { get; set; }
        [Display(Name = "Сумма премии")]
        public string PrizeAmount { get; set; }
    }

    // Вид премии
    public class Prize
    {
        [Display(Name = "Номер")]
        public int PrizeId { get; set; }
        [Display(Name = "Вид премии")]
        public string PrizeName { get; set; }
    }

    // Магазин
    public class Shop
    {
        [Display(Name = "Номер")]
        public int ShopId { get; set; }
        [Display(Name = "Название магазина")]
        public string ShopName { get; set; }
        [Display(Name = "Адрес магазина")]
        public string ShopAdress { get; set; }
        [Display(Name = "Телефон магазина")]
        public string ShopTelephone { get; set; }
        [Display(Name = "Почта магазина")]
        public string ShopEmail { get; set; }
    }

    // Клиент
    public class Client
    {
        [Display(Name = "Номер")]
        public int ClientId { get; set; }
        [Display(Name = "Имя клиента")]
        public string ClientName { get; set; }
        [Display(Name = "Телефон клиента")]
        public string ClientTelephone { get; set; }
        [Display(Name = "Почта клиента")]
        [DataType(DataType.EmailAddress)]
        public string ClientEmail { get; set; }
        [Display(Name = "Город клиента")]
        public string ClientCity { get; set; }
        [Display(Name = "Адрес клиента")]
        public string ClientAdress { get; set; }
    }

    // Покупка
    public class Purchase
    {
        [Display(Name = "Номер")]
        public int PurchaseId { get; set; }
        [Display(Name = "Товар")]
        public int PurchaseProductId { get; set; }
        public PurchaseProduct PurchaseProduct { get; set; }
        [Display(Name = "Сотрудник")]
        public int WorkerId { get; set; }
        public Worker Worker { get; set; }
        [Display(Name = "Клиент")]
        public int ClientId { get; set; }
        public Client Client { get; set; }
        [Display(Name = "Магазин")]
        public int ShopId { get; set; }
        public Shop Shop { get; set; }
        [Display(Name = "Дата покупки")]
        public DateTime PurchaseDate { get; set; }
        [Display(Name = "Полная стоимость")]
        public float PurchaseFullCost { get; set; }
        [Display(Name = "Скидка")]
        public int PurchaseDiscount { get; set; }
    }

    // Единица покупки
    public class PurchaseProduct
    {
        [Display(Name = "Номер")]
        public int PurchaseProductId { get; set; }
        [Display(Name = "Товар")]
        public int ProductId { get; set; }
        [Display(Name = "Количество товара")]
        public int PurchaseAmount { get; set; }
        [Display(Name = "Стоимость")]
        public float PurchaseCost { get; set; }
    }

    // Товар
    public class Product
    {
        [Display(Name = "Номер")]
        public int ProductId { get; set; }
        [Display(Name = "Производитель")]
        public int ManufacturerId { get; set; }
        [Display(Name = "Категория")]
        public int CategoryId { get; set; }
        [Display(Name = "Название")]
        public string ProductName { get; set; }
        [Display(Name = "Стоимость")]
        public float ProductCost { get; set; }
        [Display(Name = "Гарантия")]
        public string ProductGarantee { get; set; }
        [Display(Name = "Количество на складе")]
        public int ProductOnStock { get; set; }
    }

    // Списание товара
    public class WriteOffProduct
    {
        [Display(Name = "Номер")]
        public int WriteOffProductId { get; set; }
        [Display(Name = "Количество")]
        public int WriteOffAmount { get; set; }
        [Display(Name = "Товар")]
        public int ProductId { get; set; }
        public Product Product { get; set; }
        [Display(Name = "Дата списания")]
        public DateTime WriteOffDate { get; set; }
        [Display(Name = "Причина")]
        public int CauseId { get; set; }
        public Cause Cause { get; set; }
    }

    // Причина списания
    public class Cause
    {
        [Display(Name = "Номер")]
        public int CauseId { get; set; }
        [Display(Name = "Причина списания")]
        public string CauseName { get; set; }
    }

    // Единица в поставке
    public class SupplyProduct
    {
        [Display(Name = "Номер")]
        public int SupplyProductId { get; set; }
        public int ProductId { get; set; }
        [Display(Name = "Количество")]
        public int SupplyProductAmount { get; set; }
        [Display(Name = "Стоимость")]
        public float SupplyProductCost { get; set; }
    }

    // Поставка
    public class Supply
    {
        [Display(Name = "Номер")]
        public int SupplyId { get; set; }
        public int SupplyProductId { get; set; }
        [Display(Name = "Дата поставки")]
        public DateTime SupplyDate { get; set; }
        [Display(Name = "Полная стоимость")]
        public float SupplyFullCost { get; set; }
        [Display(Name = "Статус поставки")]
        public string SupplyStatus { get; set; }
    }

    // Поставщик
    public class Supplier
    {
        [Display(Name = "Номер")]
        public int SupplierId { get; set; }
        [Display(Name = "Название компании")]
        public string SupplierCompanyName { get; set; }
        [Display(Name = "ФИО")]
        public float SupplierName { get; set; }
        [Display(Name = "Электронная почта")]
        [DataType(DataType.EmailAddress)]
        public string SupplierEmail { get; set; }
        [Display(Name = "Телефон")]
        public string SupplierTelephone { get; set; }
        [Display(Name = "Город")]
        public string SupplierCity { get; set; }
        [Display(Name = "Адрес")]
        public string SupplierAdress { get; set; }
    }

    // Производитель
    public class Manufacturer
    {
        [Display(Name = "Номер")]
        public int ManufacturerId { get; set; }
        [Display(Name = "Товар")]
        public int ProductId { get; set; }
        public Product Product { get; set; }
        [Display(Name = "Производитель")]
        public string ManufacturerName { get; set; }
    }

    // Категории
    public class Category
    {
        [Display(Name = "Номер")]
        public int CategoryId { get; set; }
        [Display(Name = "Товар")]
        public int ProductId { get; set; }
        public Product Product { get; set; }
        [Display(Name = "Категория")]
        public int CategoryProductId { get; set; }
        public CategoryProduct CategoryProduct { get; set; }
    }

    // Категории
    public class CategoryProduct
    {
        [Display(Name = "Номер")]
        public int CategoryProductId { get; set; }
        [Display(Name = "Название категории")]
        public string CategoryName { get; set; }
    }
}
