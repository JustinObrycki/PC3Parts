using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;
using ProjectObryckiJustin.Pages.DataVisualization.MyViews;
using ProjectObryckiJustin.Pages.tblCustomer;
using ProjectObryckiJustin.Pages.tblEmployee;
using ProjectObryckiJustin.Pages.tblOrder;
using ProjectObryckiJustin.Pages.tblPart;

namespace ProjectObryckiJustin;

public partial class Jobrycki1Context : DbContext
{

    public Jobrycki1Context(DbContextOptions<Jobrycki1Context> options)
        : base(options)
    {
    }

    public virtual DbSet<TblAutoClient> TblAutoClients { get; set; }

    public virtual DbSet<TblCar> TblCars { get; set; }

    public virtual DbSet<TblCustomer> TblCustomers { get; set; }

    public virtual DbSet<TblDriver> TblDrivers { get; set; }

    public virtual DbSet<TblEmployee> TblEmployees { get; set; }

    public virtual DbSet<TblFaculty> TblFaculties { get; set; }

    public virtual DbSet<TblIncident> TblIncidents { get; set; }

    public virtual DbSet<TblIncident2> TblIncident2s { get; set; }

    public virtual DbSet<TblLease> TblLeases { get; set; }

    public virtual DbSet<TblMechanic> TblMechanics { get; set; }

    public virtual DbSet<TblOrder> TblOrders { get; set; }

    public virtual DbSet<TblPart> TblParts { get; set; }

    public virtual DbSet<TblPolice> TblPolices { get; set; }

    public virtual DbSet<TblPublicSafety> TblPublicSafeties { get; set; }

    public virtual DbSet<TblStudent> TblStudents { get; set; }

    public virtual DbSet<TblVacation> TblVacations { get; set; }

    public virtual DbSet<TblViolation> TblViolations { get; set; }

    public virtual DbSet<VwCarColor> VwCarColors { get; set; }

    public virtual DbSet<VwCustomerOrder> VwCustomerOrders { get; set; }

    public virtual DbSet<VwEmployeeSale> VwEmployeeSales { get; set; }

    public virtual DbSet<spCustomerTotal> spCustomerTotal { get; set; }

    public virtual DbSet<spEmployeeTotalSales> spEmployeeTotalSales { get; set; }
    public virtual DbSet<spSaleByDate> spSaleByDate { get; set; }
    public IConfiguration myconfig { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(myconfig.GetConnectionString("JObrycki1Connection"));

        }
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<spSaleByDate>(entity =>
        {
            entity.HasNoKey();

            entity.ToView("spSaleByDate");

            entity.Property(e => e.OrderDate);


            entity.Property(e => e.PartName);

            entity.Property(e => e.TotalCost);

            entity.Property(e => e.Quantity);

            entity.Property(e => e.Employee);

            entity.Property(e => e.Customer);

        });

        modelBuilder.Entity<spEmployeeTotalSales>(entity =>
        {
            entity.HasNoKey();

            entity.ToView("spEmployeeTotalSales");

            entity.Property(e => e.Employee);

            entity.Property(e => e.TotalSale);

        });
        modelBuilder.Entity<spCustomerTotal>(entity =>
        {
            entity.HasNoKey();

            entity.ToView("spCustomerTotal");

            entity.Property(e => e.CustomerName);

            entity.Property(e => e.TotalSpent);

        });

        modelBuilder.Entity<TblAutoClient>(entity =>
        {
            entity.HasKey(e => e.CustNo).HasName("PK__tblAutoC__049E631ACB1946CA");

            entity.ToTable("tblAutoClient");

            entity.Property(e => e.CustNo).ValueGeneratedNever();
            entity.Property(e => e.CustName)
                .HasMaxLength(25)
                .IsUnicode(false);

            entity.HasOne(d => d.MechanicNoNavigation).WithMany(p => p.TblAutoClients)
                .HasForeignKey(d => d.MechanicNo)
                .HasConstraintName("FK__tblAutoCl__Mecha__5CD6CB2B");
        });

        modelBuilder.Entity<TblCar>(entity =>
        {
            entity.HasKey(e => e.CarId).HasName("PK__tblCar__1436F174B3203D72");

            entity.ToTable("tblCar");

            entity.Property(e => e.CarId).HasColumnName("carID");
            entity.Property(e => e.CarYear)
                .HasMaxLength(4)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("carYear");
            entity.Property(e => e.Color)
                .HasMaxLength(20)
                .HasColumnName("color");
            entity.Property(e => e.Cost).HasColumnName("cost");
            entity.Property(e => e.LicensePlate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("licensePlate");
            entity.Property(e => e.Make)
                .HasMaxLength(20)
                .HasColumnName("make");
            entity.Property(e => e.Model)
                .HasMaxLength(20)
                .HasColumnName("model");
        });

        modelBuilder.Entity<TblCustomer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PK__tblCusto__A4AFBF637F659E96");

            entity.ToTable("tblCustomer");

            entity.Property(e => e.Address)
                .HasMaxLength(50)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.FirstName)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.Gender)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.LastName)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();
        });

        modelBuilder.Entity<TblDriver>(entity =>
        {
            entity.HasKey(e => e.DriverId).HasName("PK__tblDrive__F1532DF271C4771C");

            entity.ToTable("tblDriver");

            entity.Property(e => e.DriverId)
                .ValueGeneratedNever()
                .HasColumnName("driverId");
            entity.Property(e => e.Address)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("address");
            entity.Property(e => e.City)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("city");
            entity.Property(e => e.Dname)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("dname");
            entity.Property(e => e.Dstate)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("dstate");
            entity.Property(e => e.Zip)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("zip");
        });

        modelBuilder.Entity<TblEmployee>(entity =>
        {
            entity.HasKey(e => e.EmployeeId).HasName("PK__tblEmplo__7AD04F117D0EE224");

            entity.ToTable("tblEmployee");

            entity.Property(e => e.Address)
                .HasMaxLength(50)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.FirstName)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.Gender)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.LastName)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();
        });

        modelBuilder.Entity<TblFaculty>(entity =>
        {
            entity.HasKey(e => e.FacultyId).HasName("PK__tblFacul__DBBF6FD1BD4FD07D");

            entity.ToTable("tblFaculty");

            entity.Property(e => e.FacultyId).HasColumnName("facultyID");
            entity.Property(e => e.CarId).HasColumnName("carID");
            entity.Property(e => e.FacGender)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("facGender");
            entity.Property(e => e.FacName)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("facName");
            entity.Property(e => e.HireDate)
                .HasColumnType("date")
                .HasColumnName("hireDate");
            entity.Property(e => e.Salary).HasColumnName("salary");

            entity.HasOne(d => d.Car).WithMany(p => p.TblFaculties)
                .HasForeignKey(d => d.CarId)
                .HasConstraintName("FK__tblFacult__carID__2D27B809");
        });

        modelBuilder.Entity<TblIncident>(entity =>
        {
            entity.HasKey(e => e.IncidentId).HasName("PK__tblIncid__06A5D76130232082");

            entity.ToTable("tblIncident");

            entity.Property(e => e.IncidentId).HasColumnName("incidentID");
            entity.Property(e => e.Driverid).HasColumnName("driverid");
            entity.Property(e => e.IncidentDate)
                .HasColumnType("date")
                .HasColumnName("incidentDate");
            entity.Property(e => e.Policeid).HasColumnName("policeid");
            entity.Property(e => e.ViolationId).HasColumnName("violationID");

            entity.HasOne(d => d.Driver).WithMany(p => p.TblIncidents)
                .HasForeignKey(d => d.Driverid)
                .HasConstraintName("FK__tblIncide__drive__0D7A0286");

            entity.HasOne(d => d.Police).WithMany(p => p.TblIncidents)
                .HasForeignKey(d => d.Policeid)
                .HasConstraintName("FK__tblIncide__polic__0C85DE4D");

            entity.HasOne(d => d.Violation).WithMany(p => p.TblIncidents)
                .HasForeignKey(d => d.ViolationId)
                .HasConstraintName("FK__tblIncide__viola__0B91BA14");
        });

        modelBuilder.Entity<TblIncident2>(entity =>
        {
            entity.HasKey(e => e.IncidentId).HasName("PK__tblIncid__06A5D7610A365787");

            entity.ToTable("tblIncident2");

            entity.Property(e => e.IncidentId).HasColumnName("incidentID");
            entity.Property(e => e.CarId).HasColumnName("carID");
            entity.Property(e => e.Comments)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("comments");
            entity.Property(e => e.FacultyId).HasColumnName("facultyID");
            entity.Property(e => e.IncidentDate)
                .HasColumnType("date")
                .HasColumnName("incidentDate");
            entity.Property(e => e.PsafetyId).HasColumnName("psafetyID");
            entity.Property(e => e.StudentId).HasColumnName("studentID");

            entity.HasOne(d => d.Car).WithMany(p => p.TblIncident2s)
                .HasForeignKey(d => d.CarId)
                .HasConstraintName("FK__tblIncide__carID__3B75D760");

            entity.HasOne(d => d.Faculty).WithMany(p => p.TblIncident2s)
                .HasForeignKey(d => d.FacultyId)
                .HasConstraintName("FK__tblIncide__facul__398D8EEE");

            entity.HasOne(d => d.Psafety).WithMany(p => p.TblIncident2s)
                .HasForeignKey(d => d.PsafetyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tblIncide__psafe__3A81B327");

            entity.HasOne(d => d.Student).WithMany(p => p.TblIncident2s)
                .HasForeignKey(d => d.StudentId)
                .HasConstraintName("FK__tblIncide__stude__38996AB5");
        });

        modelBuilder.Entity<TblLease>(entity =>
        {
            entity.HasKey(e => e.LeaseId).HasName("PK__tblLease__C6D5C5A3C0343550");

            entity.ToTable("tblLease");

            entity.Property(e => e.LeaseId).HasColumnName("leaseID");
            entity.Property(e => e.Address)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("address");
            entity.Property(e => e.City)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("city");
            entity.Property(e => e.EndDate)
                .HasColumnType("date")
                .HasColumnName("end_date");
            entity.Property(e => e.LeaseAmount).HasColumnName("lease_amount");
            entity.Property(e => e.StartDate)
                .HasColumnType("date")
                .HasColumnName("start_date");
            entity.Property(e => e.State)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("state");
            entity.Property(e => e.Tenant)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("tenant");
            entity.Property(e => e.ZipCode)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("zip_code");
        });

        modelBuilder.Entity<TblMechanic>(entity =>
        {
            entity.HasKey(e => e.MechanicNo).HasName("PK__tblMecha__6B1B6B96100CA232");

            entity.ToTable("tblMechanic");

            entity.Property(e => e.MechanicNo).ValueGeneratedNever();
            entity.Property(e => e.MechanicName)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.ServiceDate).HasColumnType("date");
        });

        modelBuilder.Entity<TblOrder>(entity =>
        {
            entity.HasKey(e => e.OrderNo).HasName("PK__tblOrder__C3907C7445B10AE5");

            entity.ToTable("tblOrder");

            entity.Property(e => e.OrderDate).HasColumnType("date");

            entity.HasOne(d => d.Customer).WithMany(p => p.TblOrders)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK__tblOrder__Custom__1EA48E88");

            entity.HasOne(d => d.Employee).WithMany(p => p.TblOrders)
                .HasForeignKey(d => d.EmployeeId)
                .HasConstraintName("FK__tblOrder__Employ__1F98B2C1");

            entity.HasOne(d => d.Part).WithMany(p => p.TblOrders)
                .HasForeignKey(d => d.PartId)
                .HasConstraintName("FK__tblOrder__PartId__208CD6FA");
        });

        modelBuilder.Entity<TblPart>(entity =>
        {
            entity.HasKey(e => e.PartId).HasName("PK__tblParts__7C3F0D50B872ACD6");

            entity.ToTable("tblParts");

            entity.Property(e => e.Color)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.PartDescription)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PartName)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.Type)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TblPolice>(entity =>
        {
            entity.HasKey(e => e.PoliceId).HasName("PK__tblPolic__F2063982C5C04704");

            entity.ToTable("tblPolice");

            entity.Property(e => e.PoliceId)
                .ValueGeneratedNever()
                .HasColumnName("policeID");
            entity.Property(e => e.Pname)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("pname");
        });

        modelBuilder.Entity<TblPublicSafety>(entity =>
        {
            entity.HasKey(e => e.PsafetyId);

            entity.ToTable("tblPublicSafety");

            entity.Property(e => e.PsafetyId).HasColumnName("psafetyID");
            entity.Property(e => e.Badge)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("badge");
            entity.Property(e => e.PGender)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("pGender");
            entity.Property(e => e.PName)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("pName");
        });

        modelBuilder.Entity<TblStudent>(entity =>
        {
            entity.HasKey(e => e.StudentId);

            entity.ToTable("tblStudent");

            entity.Property(e => e.StudentId).HasColumnName("studentID");
            entity.Property(e => e.CarId).HasColumnName("carID");
            entity.Property(e => e.Dob)
                .HasColumnType("date")
                .HasColumnName("DOB");
            entity.Property(e => e.FName)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("fName");
            entity.Property(e => e.Gender)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("gender");
            entity.Property(e => e.LName)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("lName");
            entity.Property(e => e.Major)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("major");

            entity.HasOne(d => d.Car).WithMany(p => p.TblStudents)
                .HasForeignKey(d => d.CarId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tblStudent_tblCar1");
        });

        modelBuilder.Entity<TblVacation>(entity =>
        {
            entity.HasKey(e => e.VacationId).HasName("PK__tblVacat__E420DF849CB4D2B2");

            entity.ToTable("tblVacation");

            entity.Property(e => e.VacationId).HasColumnName("VacationID");
            entity.Property(e => e.City)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.Country)
                .HasMaxLength(25)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TblViolation>(entity =>
        {
            entity.HasKey(e => e.ViolationId).HasName("PK__tblViola__68930B70CF4621DE");

            entity.ToTable("tblViolation");

            entity.Property(e => e.ViolationId)
                .ValueGeneratedNever()
                .HasColumnName("violationID");
            entity.Property(e => e.Fine).HasColumnName("fine");
            entity.Property(e => e.Violation)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("violation");
        });

        modelBuilder.Entity<VwCarColor>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vwCarColor");

            entity.Property(e => e.Color)
                .HasMaxLength(20)
                .HasColumnName("color");
            entity.Property(e => e.Cost).HasColumnName("cost");
            entity.Property(e => e.Make)
                .HasMaxLength(20)
                .HasColumnName("make");
            entity.Property(e => e.Model)
                .HasMaxLength(20)
                .HasColumnName("model");
        });

        modelBuilder.Entity<VwCustomerOrder>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vwCustomerOrders");

            entity.Property(e => e.FirstName)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.Gender)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.LastName)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.OrderDate).HasColumnType("date");
            entity.Property(e => e.PartDescription)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PartName)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.TotalCost).HasColumnName("Total Cost");
            entity.Property(e => e.Type)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<VwEmployeeSale>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vwEmployeeSales");

            entity.Property(e => e.DateOfSale)
                .HasColumnType("date")
                .HasColumnName("Date Of Sale");
            entity.Property(e => e.Employee)
                .HasMaxLength(51)
                .IsUnicode(false);
            entity.Property(e => e.PartCost).HasColumnName("Part Cost");
            entity.Property(e => e.PartSold)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("Part Sold");
            entity.Property(e => e.QuantitySold).HasColumnName("Quantity Sold");
            entity.Property(e => e.TotalSale).HasColumnName("Total Sale");
            entity.Property(e => e.Type)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
