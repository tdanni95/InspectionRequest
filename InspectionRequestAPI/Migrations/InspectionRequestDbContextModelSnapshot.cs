﻿// <auto-generated />
using System;
using InspectionRequestAPI.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace InspectionRequestAPI.Migrations
{
    [DbContext(typeof(InspectionRequestDbContext))]
    partial class InspectionRequestDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.2");

            modelBuilder.Entity("ChemicalInspectionParticle", b =>
                {
                    b.Property<Guid>("ChemicalInspectionsId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ParticlesId")
                        .HasColumnType("TEXT");

                    b.HasKey("ChemicalInspectionsId", "ParticlesId");

                    b.HasIndex("ParticlesId");

                    b.ToTable("ChemicalInspectionParticle");
                });

            modelBuilder.Entity("InspectionInspectionRequest", b =>
                {
                    b.Property<Guid>("InspectionRequestsId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("InspectionsId")
                        .HasColumnType("TEXT");

                    b.HasKey("InspectionRequestsId", "InspectionsId");

                    b.HasIndex("InspectionsId");

                    b.ToTable("InspectionInspectionRequest");
                });

            modelBuilder.Entity("InspectionRequestAPI.Entities.Attendance", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("attendances");
                });

            modelBuilder.Entity("InspectionRequestAPI.Entities.BlockedTimes", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<bool>("AllDay")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("From")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("To")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("blockedTimes");
                });

            modelBuilder.Entity("InspectionRequestAPI.Entities.ChemicalInspection", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("DangerComment")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("MustDiscardAfterInspection")
                        .HasColumnType("INTEGER");

                    b.Property<Guid>("ParentInspectionId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ParentInspectionId");

                    b.ToTable("chemicalInspections");
                });

            modelBuilder.Entity("InspectionRequestAPI.Entities.Inspection", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("FinishedAd")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<uint>("Order")
                        .HasColumnType("INTEGER");

                    b.Property<Guid>("ToolId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ToolId");

                    b.ToTable("inspections");
                });

            modelBuilder.Entity("InspectionRequestAPI.Entities.InspectionRequest", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Created")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("FinishDate")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("InspectionTypeId")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsWaste")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("LastModifiedBy")
                        .HasColumnType("TEXT");

                    b.Property<string>("PartNumber")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<uint>("Prio")
                        .HasColumnType("INTEGER");

                    b.Property<Guid>("RequestorId")
                        .HasColumnType("TEXT");

                    b.Property<string>("RequestorRequest")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<uint>("SubPrio")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Visible")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("InspectionTypeId");

                    b.HasIndex("RequestorId");

                    b.ToTable("inspectionRequests");
                });

            modelBuilder.Entity("InspectionRequestAPI.Entities.InspectionType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("inspectionTypes");
                });

            modelBuilder.Entity("InspectionRequestAPI.Entities.MechanicalInspection", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<uint>("Depth")
                        .HasColumnType("INTEGER");

                    b.Property<uint>("Length")
                        .HasColumnType("INTEGER");

                    b.Property<Guid>("ParentInspectionId")
                        .HasColumnType("TEXT");

                    b.Property<string>("StructuralIntegrity")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<uint>("Width")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ParentInspectionId");

                    b.ToTable("mechanicalInspections");
                });

            modelBuilder.Entity("InspectionRequestAPI.Entities.Particle", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<uint>("Size")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("particles");
                });

            modelBuilder.Entity("InspectionRequestAPI.Entities.Tool", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("tools");
                });

            modelBuilder.Entity("InspectionRequestAPI.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ForName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsEngineer")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("SurName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("users");
                });

            modelBuilder.Entity("ToolUser", b =>
                {
                    b.Property<Guid>("EngineersWhoCanUseId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ToolsICanUseId")
                        .HasColumnType("TEXT");

                    b.HasKey("EngineersWhoCanUseId", "ToolsICanUseId");

                    b.HasIndex("ToolsICanUseId");

                    b.ToTable("ToolUser");
                });

            modelBuilder.Entity("ChemicalInspectionParticle", b =>
                {
                    b.HasOne("InspectionRequestAPI.Entities.ChemicalInspection", null)
                        .WithMany()
                        .HasForeignKey("ChemicalInspectionsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("InspectionRequestAPI.Entities.Particle", null)
                        .WithMany()
                        .HasForeignKey("ParticlesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("InspectionInspectionRequest", b =>
                {
                    b.HasOne("InspectionRequestAPI.Entities.InspectionRequest", null)
                        .WithMany()
                        .HasForeignKey("InspectionRequestsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("InspectionRequestAPI.Entities.Inspection", null)
                        .WithMany()
                        .HasForeignKey("InspectionsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("InspectionRequestAPI.Entities.Attendance", b =>
                {
                    b.HasOne("InspectionRequestAPI.Entities.User", null)
                        .WithMany("Attendances")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("InspectionRequestAPI.Entities.ChemicalInspection", b =>
                {
                    b.HasOne("InspectionRequestAPI.Entities.InspectionRequest", "ParentInspection")
                        .WithMany()
                        .HasForeignKey("ParentInspectionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ParentInspection");
                });

            modelBuilder.Entity("InspectionRequestAPI.Entities.Inspection", b =>
                {
                    b.HasOne("InspectionRequestAPI.Entities.Tool", "Tool")
                        .WithMany("Inspections")
                        .HasForeignKey("ToolId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tool");
                });

            modelBuilder.Entity("InspectionRequestAPI.Entities.InspectionRequest", b =>
                {
                    b.HasOne("InspectionRequestAPI.Entities.InspectionType", "InspectionType")
                        .WithMany()
                        .HasForeignKey("InspectionTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("InspectionRequestAPI.Entities.User", "Requestor")
                        .WithMany()
                        .HasForeignKey("RequestorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("InspectionType");

                    b.Navigation("Requestor");
                });

            modelBuilder.Entity("InspectionRequestAPI.Entities.MechanicalInspection", b =>
                {
                    b.HasOne("InspectionRequestAPI.Entities.InspectionRequest", "ParentInspection")
                        .WithMany()
                        .HasForeignKey("ParentInspectionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ParentInspection");
                });

            modelBuilder.Entity("InspectionRequestAPI.Entities.User", b =>
                {
                    b.OwnsOne("InspectionRequestAPI.Entities.RefreshToken", "RefreshToken", b1 =>
                        {
                            b1.Property<Guid>("UserId")
                                .HasColumnType("TEXT");

                            b1.Property<DateTime>("Created")
                                .HasColumnType("TEXT");

                            b1.Property<DateTime>("Expires")
                                .HasColumnType("TEXT");

                            b1.Property<string>("Token")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.HasKey("UserId");

                            b1.ToTable("users");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.Navigation("RefreshToken");
                });

            modelBuilder.Entity("ToolUser", b =>
                {
                    b.HasOne("InspectionRequestAPI.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("EngineersWhoCanUseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("InspectionRequestAPI.Entities.Tool", null)
                        .WithMany()
                        .HasForeignKey("ToolsICanUseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("InspectionRequestAPI.Entities.Tool", b =>
                {
                    b.Navigation("Inspections");
                });

            modelBuilder.Entity("InspectionRequestAPI.Entities.User", b =>
                {
                    b.Navigation("Attendances");
                });
#pragma warning restore 612, 618
        }
    }
}
