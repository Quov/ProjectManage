using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using eTeamProjectManagement.Data;

namespace eTeamProjectManagement.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20170204191500_updatesitems")]
    partial class updatesitems
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("eTeamProjectManagement.Entities.IssueData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateLogged");

                    b.Property<DateTime>("DateResolved");

                    b.Property<string>("Description");

                    b.Property<bool>("IsActive");

                    b.Property<int?>("IssueTypeId");

                    b.Property<string>("LoggedBy");

                    b.Property<string>("Status");

                    b.HasKey("Id");

                    b.HasIndex("IssueTypeId");

                    b.ToTable("IssueData");
                });

            modelBuilder.Entity("eTeamProjectManagement.Entities.IssueTypes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("IssueType");

                    b.HasKey("Id");

                    b.ToTable("IssueTypes");
                });

            modelBuilder.Entity("eTeamProjectManagement.Entities.IssueUpdate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<DateTime>("InitialLogged");

                    b.Property<string>("InitialLoggedBy");

                    b.Property<int>("IssueId");

                    b.Property<int>("IssueUpdateId");

                    b.Property<string>("ModifiedBy");

                    b.Property<DateTime>("ModifiedOn");

                    b.Property<string>("UpdateType");

                    b.HasKey("Id");

                    b.ToTable("IssueUpdates");
                });

            modelBuilder.Entity("eTeamProjectManagement.Entities.ProjectContactData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ContactEmail");

                    b.Property<string>("ContactNote");

                    b.Property<string>("ContactPhone");

                    b.Property<string>("ContactRole");

                    b.Property<string>("ContactTimeZone");

                    b.Property<int>("ProjectContactId");

                    b.Property<int>("ProjectId");

                    b.HasKey("Id");

                    b.ToTable("ProjectContactData");
                });

            modelBuilder.Entity("eTeamProjectManagement.Entities.ProjectData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AssignedTeam")
                        .IsRequired();

                    b.Property<DateTime>("BeginDate");

                    b.Property<string>("BillToClientNumber")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 6);

                    b.Property<string>("ClientName")
                        .IsRequired();

                    b.Property<string>("ClientNumber")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 6);

                    b.Property<string>("Cst");

                    b.Property<string>("Description");

                    b.Property<int>("PriorityId");

                    b.Property<string>("ProjectOwner")
                        .IsRequired();

                    b.Property<int>("ProjectTypeId");

                    b.Property<int>("StatusId");

                    b.Property<bool>("isActive");

                    b.HasKey("Id");

                    b.ToTable("ProjectData");
                });

            modelBuilder.Entity("eTeamProjectManagement.Entities.ProjectITUpdate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<DateTime>("InitialUpdate");

                    b.Property<DateTime>("LastModified");

                    b.Property<int>("ProjectITUpdateId");

                    b.Property<int>("ProjectId");

                    b.Property<int>("UpdateFromId");

                    b.Property<int>("UpdateTypeId");

                    b.Property<string>("UpdatedBy");

                    b.HasKey("Id");

                    b.ToTable("ProjectITUpdates");
                });

            modelBuilder.Entity("eTeamProjectManagement.Entities.ProjectPriorities", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ProjectPriority");

                    b.HasKey("Id");

                    b.ToTable("ProjectPriorities");
                });

            modelBuilder.Entity("eTeamProjectManagement.Entities.ProjectStatuses", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ProjectStatus");

                    b.HasKey("Id");

                    b.ToTable("ProjectStatuses");
                });

            modelBuilder.Entity("eTeamProjectManagement.Entities.ProjectTeamUpdate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<DateTime>("InitialUpdate");

                    b.Property<DateTime>("LastModified");

                    b.Property<int>("ProjectId");

                    b.Property<int>("ProjectUpdateId");

                    b.Property<int>("UpdateFromId");

                    b.Property<int>("UpdateTypeId");

                    b.Property<string>("UpdatedBy");

                    b.HasKey("Id");

                    b.ToTable("ProjectTeamUpdates");
                });

            modelBuilder.Entity("eTeamProjectManagement.Entities.ProjectTypes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ProjectType");

                    b.HasKey("Id");

                    b.ToTable("ProjectTypes");
                });

            modelBuilder.Entity("eTeamProjectManagement.Entities.ProjectUpdatePartys", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("UpdateParty");

                    b.HasKey("Id");

                    b.ToTable("ProjectUpdatePartys");
                });

            modelBuilder.Entity("eTeamProjectManagement.Entities.ProjectUpdateTypes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ProjectUpdateType");

                    b.HasKey("Id");

                    b.ToTable("ProjectUpdateTypes");
                });

            modelBuilder.Entity("eTeamProjectManagement.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id");

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedUserName")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole", b =>
                {
                    b.Property<string>("Id");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("eTeamProjectManagement.Entities.IssueData", b =>
                {
                    b.HasOne("eTeamProjectManagement.Entities.IssueTypes", "IssueType")
                        .WithMany()
                        .HasForeignKey("IssueTypeId");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Claims")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("eTeamProjectManagement.Models.ApplicationUser")
                        .WithMany("Claims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("eTeamProjectManagement.Models.ApplicationUser")
                        .WithMany("Logins")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("eTeamProjectManagement.Models.ApplicationUser")
                        .WithMany("Roles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
