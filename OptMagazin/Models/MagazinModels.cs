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
        public int WorkerId { get; set; }
        public string WorkerName { get; set; }
        public Gender WorkerGender { get; set; }
        public DateTime WorkerBirthday { get; set; }
        public string FamilyStatus { get; set; }
        public string WorkerTelephone { get; set; }
        [DataType(DataType.EmailAddress)]
        public string WorkerEmail { get; set; }
        public int PassportSeries { get; set; }
        public int PassportNumber { get; set; }
        public int Inn { get; set; }
    }

    // Ребенок сотрудника
    public class WorkerChild
    {
        public int WorkerChildId { get; set; }
        public int WorkerId { get; set; }
        public Worker Worker { get; set; }
        public string ChildName { get; set; }
        public Gender ChildGender { get; set; }
        public DateTime ChildBirthday { get; set; }
        public string StudyPlace { get; set; }
    }

    // Отпуск
    public class Vacation
    {
        public int VacationId { get; set; }
        public int WorkerId { get; set; }
        public Worker Worker { get; set; }
        public DateTime VacationStart { get; set; }
        public DateTime VacationEnd { get; set; }
        public int VacationSortId { get; set; }
        public VacationSort VacationSort { get; set; }
        public string VacationStatus { get; set; }
    }

    // Вид отпуска
    public class VacationSort
    {
        public int VacationSortId { get; set; }
        public string VacationName { get; set; }
    }

    // Образование сотрудника
    public class WorkerEducation
    {
        public int WorkerEducationId { get; set; }
        public int WorkerId { get; set; }
        public Worker Worker { get; set; }
        public int UniversityId { get; set; }
        public University University { get; set; }
        public DateTime EducationStart { get; set; }
        public DateTime EducationEnd { get; set; }
        public int EducationSpecialtyId { get; set; }
        public EducationSpecialty EducationSpecialty { get; set; }

    }

    // Место учебы
    public class University
    {
        public int UniversityId { get; set; }
        public string UniversityName { get; set; }
    }

    // Специальность
    public class EducationSpecialty
    {
        public int EducationSpecialtyId { get; set; }
        public string EducationSpecialtyName { get; set; }
    }

    // Должность
    public class WorkerPost
    {
        public int WorkerPostId { get; set; }
        public int PostId { get; set; }
        public Post Post { get; set; }
        public int WorkerId { get; set; }
        public Worker Worker { get; set; }
    }

    // Вид должности
    public class Post
    {
        public int PostId { get; set; }
        public string PostName { get; set; }
    }

    // Премия
    public class WorkerPrize
    {
        public int WorkerPrizeId { get; set; }
        public int WorkerId { get; set; }
        public Worker Worker { get; set; }
        public DateTime PrizeDate { get; set; }
        public int PrizeId { get; set; }
        public Prize Prize { get; set; }
        public string PrizeAmount { get; set; }
    }

    // Вид премии
    public class Prize
    {
        public int PrizeId { get; set; }
        public string PrizeName { get; set; }
    }

    // Магазин
    public class Shop
    {
        public int ShopId { get; set; }
        public string ShopName { get; set; }
        public string ShopAdress { get; set; }
        public string ShopTelephone { get; set; }
        public string ShopEmail { get; set; }
    }

    // Клиент
    public class Client
    {
        public int ClientId { get; set; }
        public string ClientName { get; set; }
        public string ClientTelephone { get; set; }
        [DataType(DataType.EmailAddress)]
        public string ClientEmail { get; set; }
        public string ClientCity { get; set; }
        public string ClientAdress { get; set; }
    }

    // Покупка
    public class Purchase
    {
        public int PurchaseId { get; set; }
        public int PurchaseProductId { get; set; }
        public PurchaseProduct PurchaseProduct { get; set; }
        public int WorkerId { get; set; }
        public Worker Worker { get; set; }
        public int ClientId { get; set; }
        public Client Client { get; set; }
        public int ShopId { get; set; }
        public Shop Shop { get; set; }
        public DateTime PurchaseDate { get; set; }
        public float PurchaseFullCost { get; set; }
        public int PurchaseDiscount { get; set; }
    }

    // Единица покупки
    public class PurchaseProduct
    {
        public int PurchaseProductId { get; set; }
        public int ProductId { get; set; }
        public int PurchaseAmount { get; set; }
        public float PurchaseCost { get; set; }
    }

    // Товар
    public class Product
    {
        public int ProductId { get; set; }
        public int ManufacturerId { get; set; }
        public int CategoryId { get; set; }

        public string ProductName { get; set; }
        public float ProductCost { get; set; }
        public string ProductGarantee { get; set; }
        public string ProductOnStock { get; set; }
    }

    // Списание товара
    public class WriteOffProduct
    {
        public int WriteOffProductId { get; set; }
        public int WriteOffAmount { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public DateTime WriteOffDate { get; set; }
        public int CauseId { get; set; }
        public Cause Cause { get; set; }
    }

    // Причина списания
    public class Cause
    {
        public int CauseId { get; set; }
        public string CauseName { get; set; }
    }

    // Единица в поставке
    public class SupplyProduct
    {
        public int SupplyProductId { get; set; }
        public int ProductId { get; set; }
        public int SupplyProductAmount { get; set; }
        public float SupplyProductCost { get; set; }
    }

    // Поставка
    public class Supply
    {
        public int SupplyId { get; set; }
        public int SupplyProductId { get; set; }
        public DateTime SupplyDate { get; set; }
        public float SupplyFullCost { get; set; }
        public string SupplyStatus { get; set; }
    }

    // Поставщик
    public class Supplier
    {
        public int SupplierId { get; set; }
        public string SupplierCompanyName { get; set; }
        public float SupplierName { get; set; }
        [DataType(DataType.EmailAddress)]
        public string SupplierEmail { get; set; }
        public string SupplierTelephone { get; set; }
        public string SupplierCity { get; set; }
        public string SupplierAdress { get; set; }
    }

    // Производитель
    public class Manufacturer
    {
        public int ManufacturerId { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public string ManufacturerName { get; set; }
    }

    // Категории
    public class Category
    {
        public int CategoryId { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int CategoryProductId { get; set; }
        public CategoryProduct CategoryProduct { get; set; }
    }

    // Категории
    public class CategoryProduct
    {
        public int CategoryProductId { get; set; }
        public string CategoryName { get; set; }
    }
}
