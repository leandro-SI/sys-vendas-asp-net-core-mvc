﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VendasWebMvc.Models;

namespace VendasWebMvc.Migrations
{
    [DbContext(typeof(VendasWebMvcContext))]
    [Migration("20190126015856_DepartmentForeignkey")]
    partial class DepartmentForeignkey
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("VendasWebMvc.Models.Departamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Departamento");
                });

            modelBuilder.Entity("VendasWebMvc.Models.RegistroDeVendas", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Data");

                    b.Property<double>("Quantidade");

                    b.Property<int>("Status");

                    b.Property<int?>("vendedorId");

                    b.HasKey("Id");

                    b.HasIndex("vendedorId");

                    b.ToTable("registroDeVendas");
                });

            modelBuilder.Entity("VendasWebMvc.Models.Vendedor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DataDeNascimento");

                    b.Property<int>("DepartamentoId");

                    b.Property<string>("Email");

                    b.Property<string>("Nome");

                    b.Property<double>("SalarioBase");

                    b.HasKey("Id");

                    b.HasIndex("DepartamentoId");

                    b.ToTable("Vendedor");
                });

            modelBuilder.Entity("VendasWebMvc.Models.RegistroDeVendas", b =>
                {
                    b.HasOne("VendasWebMvc.Models.Vendedor", "vendedor")
                        .WithMany("registroVendas")
                        .HasForeignKey("vendedorId");
                });

            modelBuilder.Entity("VendasWebMvc.Models.Vendedor", b =>
                {
                    b.HasOne("VendasWebMvc.Models.Departamento", "departamento")
                        .WithMany("vendedores")
                        .HasForeignKey("DepartamentoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
