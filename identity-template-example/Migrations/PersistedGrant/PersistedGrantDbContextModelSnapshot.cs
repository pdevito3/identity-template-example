﻿// <auto-generated />
using System;
using Duende.IdentityServer.EntityFramework.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace identitytemplateexample.Migrations.PersistedGrant
{
    [DbContext(typeof(PersistedGrantDbContext))]
    partial class PersistedGrantDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Duende.IdentityServer.EntityFramework.Entities.DeviceFlowCodes", b =>
                {
                    b.Property<string>("UserCode")
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)")
                        .HasColumnName("user_code");

                    b.Property<string>("ClientId")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)")
                        .HasColumnName("client_id");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("creation_time");

                    b.Property<string>("Data")
                        .IsRequired()
                        .HasMaxLength(50000)
                        .HasColumnType("character varying(50000)")
                        .HasColumnName("data");

                    b.Property<string>("Description")
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)")
                        .HasColumnName("description");

                    b.Property<string>("DeviceCode")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)")
                        .HasColumnName("device_code");

                    b.Property<DateTime?>("Expiration")
                        .IsRequired()
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("expiration");

                    b.Property<string>("SessionId")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("session_id");

                    b.Property<string>("SubjectId")
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)")
                        .HasColumnName("subject_id");

                    b.HasKey("UserCode")
                        .HasName("pk_device_codes");

                    b.HasIndex("DeviceCode")
                        .IsUnique()
                        .HasDatabaseName("ix_device_codes_device_code");

                    b.HasIndex("Expiration")
                        .HasDatabaseName("ix_device_codes_expiration");

                    b.ToTable("DeviceCodes", (string)null);
                });

            modelBuilder.Entity("Duende.IdentityServer.EntityFramework.Entities.Key", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text")
                        .HasColumnName("id");

                    b.Property<string>("Algorithm")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("algorithm");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created");

                    b.Property<string>("Data")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("data");

                    b.Property<bool>("DataProtected")
                        .HasColumnType("boolean")
                        .HasColumnName("data_protected");

                    b.Property<bool>("IsX509Certificate")
                        .HasColumnType("boolean")
                        .HasColumnName("is_x509certificate");

                    b.Property<string>("Use")
                        .HasColumnType("text")
                        .HasColumnName("use");

                    b.Property<int>("Version")
                        .HasColumnType("integer")
                        .HasColumnName("version");

                    b.HasKey("Id")
                        .HasName("pk_keys");

                    b.HasIndex("Use")
                        .HasDatabaseName("ix_keys_use");

                    b.ToTable("Keys", (string)null);
                });

            modelBuilder.Entity("Duende.IdentityServer.EntityFramework.Entities.PersistedGrant", b =>
                {
                    b.Property<string>("Key")
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)")
                        .HasColumnName("key");

                    b.Property<string>("ClientId")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)")
                        .HasColumnName("client_id");

                    b.Property<DateTime?>("ConsumedTime")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("consumed_time");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("creation_time");

                    b.Property<string>("Data")
                        .IsRequired()
                        .HasMaxLength(50000)
                        .HasColumnType("character varying(50000)")
                        .HasColumnName("data");

                    b.Property<string>("Description")
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)")
                        .HasColumnName("description");

                    b.Property<DateTime?>("Expiration")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("expiration");

                    b.Property<string>("SessionId")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("session_id");

                    b.Property<string>("SubjectId")
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)")
                        .HasColumnName("subject_id");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("type");

                    b.HasKey("Key")
                        .HasName("pk_persisted_grants");

                    b.HasIndex("ConsumedTime")
                        .HasDatabaseName("ix_persisted_grants_consumed_time");

                    b.HasIndex("Expiration")
                        .HasDatabaseName("ix_persisted_grants_expiration");

                    b.HasIndex("SubjectId", "ClientId", "Type")
                        .HasDatabaseName("ix_persisted_grants_subject_id_client_id_type");

                    b.HasIndex("SubjectId", "SessionId", "Type")
                        .HasDatabaseName("ix_persisted_grants_subject_id_session_id_type");

                    b.ToTable("PersistedGrants", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
