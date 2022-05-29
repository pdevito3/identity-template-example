using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace identitytemplateexample.Migrations.Configuration
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApiResources",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    display_name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    description = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    allowed_access_token_signing_algorithms = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    show_in_discovery_document = table.Column<bool>(type: "boolean", nullable: false),
                    require_resource_indicator = table.Column<bool>(type: "boolean", nullable: false),
                    created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    last_accessed = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    non_editable = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_api_resources", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ApiScopes",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    display_name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    description = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    required = table.Column<bool>(type: "boolean", nullable: false),
                    emphasize = table.Column<bool>(type: "boolean", nullable: false),
                    show_in_discovery_document = table.Column<bool>(type: "boolean", nullable: false),
                    created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    last_accessed = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    non_editable = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_api_scopes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    client_id = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    protocol_type = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    require_client_secret = table.Column<bool>(type: "boolean", nullable: false),
                    client_name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    description = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    client_uri = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: true),
                    logo_uri = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: true),
                    require_consent = table.Column<bool>(type: "boolean", nullable: false),
                    allow_remember_consent = table.Column<bool>(type: "boolean", nullable: false),
                    always_include_user_claims_in_id_token = table.Column<bool>(type: "boolean", nullable: false),
                    require_pkce = table.Column<bool>(type: "boolean", nullable: false),
                    allow_plain_text_pkce = table.Column<bool>(type: "boolean", nullable: false),
                    require_request_object = table.Column<bool>(type: "boolean", nullable: false),
                    allow_access_tokens_via_browser = table.Column<bool>(type: "boolean", nullable: false),
                    front_channel_logout_uri = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: true),
                    front_channel_logout_session_required = table.Column<bool>(type: "boolean", nullable: false),
                    back_channel_logout_uri = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: true),
                    back_channel_logout_session_required = table.Column<bool>(type: "boolean", nullable: false),
                    allow_offline_access = table.Column<bool>(type: "boolean", nullable: false),
                    identity_token_lifetime = table.Column<int>(type: "integer", nullable: false),
                    allowed_identity_token_signing_algorithms = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    access_token_lifetime = table.Column<int>(type: "integer", nullable: false),
                    authorization_code_lifetime = table.Column<int>(type: "integer", nullable: false),
                    consent_lifetime = table.Column<int>(type: "integer", nullable: true),
                    absolute_refresh_token_lifetime = table.Column<int>(type: "integer", nullable: false),
                    sliding_refresh_token_lifetime = table.Column<int>(type: "integer", nullable: false),
                    refresh_token_usage = table.Column<int>(type: "integer", nullable: false),
                    update_access_token_claims_on_refresh = table.Column<bool>(type: "boolean", nullable: false),
                    refresh_token_expiration = table.Column<int>(type: "integer", nullable: false),
                    access_token_type = table.Column<int>(type: "integer", nullable: false),
                    enable_local_login = table.Column<bool>(type: "boolean", nullable: false),
                    include_jwt_id = table.Column<bool>(type: "boolean", nullable: false),
                    always_send_client_claims = table.Column<bool>(type: "boolean", nullable: false),
                    client_claims_prefix = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    pair_wise_subject_salt = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    user_sso_lifetime = table.Column<int>(type: "integer", nullable: true),
                    user_code_type = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    device_code_lifetime = table.Column<int>(type: "integer", nullable: false),
                    ciba_lifetime = table.Column<int>(type: "integer", nullable: true),
                    polling_interval = table.Column<int>(type: "integer", nullable: true),
                    created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    last_accessed = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    non_editable = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_clients", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "IdentityProviders",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    scheme = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    display_name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    type = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    properties = table.Column<string>(type: "text", nullable: true),
                    created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    last_accessed = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    non_editable = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_identity_providers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "IdentityResources",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    display_name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    description = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    required = table.Column<bool>(type: "boolean", nullable: false),
                    emphasize = table.Column<bool>(type: "boolean", nullable: false),
                    show_in_discovery_document = table.Column<bool>(type: "boolean", nullable: false),
                    created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    non_editable = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_identity_resources", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ApiResourceClaims",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    api_resource_id = table.Column<int>(type: "integer", nullable: false),
                    type = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_api_resource_claims", x => x.id);
                    table.ForeignKey(
                        name: "fk_api_resource_claims_api_resources_api_resource_id",
                        column: x => x.api_resource_id,
                        principalTable: "ApiResources",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ApiResourceProperties",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    api_resource_id = table.Column<int>(type: "integer", nullable: false),
                    key = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    value = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_api_resource_properties", x => x.id);
                    table.ForeignKey(
                        name: "fk_api_resource_properties_api_resources_api_resource_id",
                        column: x => x.api_resource_id,
                        principalTable: "ApiResources",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ApiResourceScopes",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    scope = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    api_resource_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_api_resource_scopes", x => x.id);
                    table.ForeignKey(
                        name: "fk_api_resource_scopes_api_resources_api_resource_id",
                        column: x => x.api_resource_id,
                        principalTable: "ApiResources",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ApiResourceSecrets",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    api_resource_id = table.Column<int>(type: "integer", nullable: false),
                    description = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    value = table.Column<string>(type: "character varying(4000)", maxLength: 4000, nullable: false),
                    expiration = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    type = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_api_resource_secrets", x => x.id);
                    table.ForeignKey(
                        name: "fk_api_resource_secrets_api_resources_api_resource_id",
                        column: x => x.api_resource_id,
                        principalTable: "ApiResources",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ApiScopeClaims",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    scope_id = table.Column<int>(type: "integer", nullable: false),
                    type = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_api_scope_claims", x => x.id);
                    table.ForeignKey(
                        name: "fk_api_scope_claims_api_scopes_scope_id",
                        column: x => x.scope_id,
                        principalTable: "ApiScopes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ApiScopeProperties",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    scope_id = table.Column<int>(type: "integer", nullable: false),
                    key = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    value = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_api_scope_properties", x => x.id);
                    table.ForeignKey(
                        name: "fk_api_scope_properties_api_scopes_scope_id",
                        column: x => x.scope_id,
                        principalTable: "ApiScopes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClientClaims",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    type = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    value = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    client_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_client_claims", x => x.id);
                    table.ForeignKey(
                        name: "fk_client_claims_clients_client_id",
                        column: x => x.client_id,
                        principalTable: "Clients",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClientCorsOrigins",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    origin = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    client_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_client_cors_origins", x => x.id);
                    table.ForeignKey(
                        name: "fk_client_cors_origins_clients_client_id",
                        column: x => x.client_id,
                        principalTable: "Clients",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClientGrantTypes",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    grant_type = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    client_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_client_grant_types", x => x.id);
                    table.ForeignKey(
                        name: "fk_client_grant_types_clients_client_id",
                        column: x => x.client_id,
                        principalTable: "Clients",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClientIdPRestrictions",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    provider = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    client_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_client_id_p_restrictions", x => x.id);
                    table.ForeignKey(
                        name: "fk_client_id_p_restrictions_clients_client_id",
                        column: x => x.client_id,
                        principalTable: "Clients",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClientPostLogoutRedirectUris",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    post_logout_redirect_uri = table.Column<string>(type: "character varying(400)", maxLength: 400, nullable: false),
                    client_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_client_post_logout_redirect_uris", x => x.id);
                    table.ForeignKey(
                        name: "fk_client_post_logout_redirect_uris_clients_client_id",
                        column: x => x.client_id,
                        principalTable: "Clients",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClientProperties",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    client_id = table.Column<int>(type: "integer", nullable: false),
                    key = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    value = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_client_properties", x => x.id);
                    table.ForeignKey(
                        name: "fk_client_properties_clients_client_id",
                        column: x => x.client_id,
                        principalTable: "Clients",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClientRedirectUris",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    redirect_uri = table.Column<string>(type: "character varying(400)", maxLength: 400, nullable: false),
                    client_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_client_redirect_uris", x => x.id);
                    table.ForeignKey(
                        name: "fk_client_redirect_uris_clients_client_id",
                        column: x => x.client_id,
                        principalTable: "Clients",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClientScopes",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    scope = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    client_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_client_scopes", x => x.id);
                    table.ForeignKey(
                        name: "fk_client_scopes_clients_client_id",
                        column: x => x.client_id,
                        principalTable: "Clients",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClientSecrets",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    client_id = table.Column<int>(type: "integer", nullable: false),
                    description = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: true),
                    value = table.Column<string>(type: "character varying(4000)", maxLength: 4000, nullable: false),
                    expiration = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    type = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_client_secrets", x => x.id);
                    table.ForeignKey(
                        name: "fk_client_secrets_clients_client_id",
                        column: x => x.client_id,
                        principalTable: "Clients",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IdentityResourceClaims",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    identity_resource_id = table.Column<int>(type: "integer", nullable: false),
                    type = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_identity_resource_claims", x => x.id);
                    table.ForeignKey(
                        name: "fk_identity_resource_claims_identity_resources_identity_resource_",
                        column: x => x.identity_resource_id,
                        principalTable: "IdentityResources",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IdentityResourceProperties",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    identity_resource_id = table.Column<int>(type: "integer", nullable: false),
                    key = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    value = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_identity_resource_properties", x => x.id);
                    table.ForeignKey(
                        name: "fk_identity_resource_properties_identity_resources_identity_resou",
                        column: x => x.identity_resource_id,
                        principalTable: "IdentityResources",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_api_resource_claims_api_resource_id_type",
                table: "ApiResourceClaims",
                columns: new[] { "api_resource_id", "type" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_api_resource_properties_api_resource_id_key",
                table: "ApiResourceProperties",
                columns: new[] { "api_resource_id", "key" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_api_resources_name",
                table: "ApiResources",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_api_resource_scopes_api_resource_id_scope",
                table: "ApiResourceScopes",
                columns: new[] { "api_resource_id", "scope" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_api_resource_secrets_api_resource_id",
                table: "ApiResourceSecrets",
                column: "api_resource_id");

            migrationBuilder.CreateIndex(
                name: "ix_api_scope_claims_scope_id_type",
                table: "ApiScopeClaims",
                columns: new[] { "scope_id", "type" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_api_scope_properties_scope_id_key",
                table: "ApiScopeProperties",
                columns: new[] { "scope_id", "key" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_api_scopes_name",
                table: "ApiScopes",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_client_claims_client_id_type_value",
                table: "ClientClaims",
                columns: new[] { "client_id", "type", "value" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_client_cors_origins_client_id_origin",
                table: "ClientCorsOrigins",
                columns: new[] { "client_id", "origin" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_client_grant_types_client_id_grant_type",
                table: "ClientGrantTypes",
                columns: new[] { "client_id", "grant_type" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_client_id_p_restrictions_client_id_provider",
                table: "ClientIdPRestrictions",
                columns: new[] { "client_id", "provider" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_client_post_logout_redirect_uris_client_id_post_logout_redirect",
                table: "ClientPostLogoutRedirectUris",
                columns: new[] { "client_id", "post_logout_redirect_uri" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_client_properties_client_id_key",
                table: "ClientProperties",
                columns: new[] { "client_id", "key" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_client_redirect_uris_client_id_redirect_uri",
                table: "ClientRedirectUris",
                columns: new[] { "client_id", "redirect_uri" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_clients_client_id",
                table: "Clients",
                column: "client_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_client_scopes_client_id_scope",
                table: "ClientScopes",
                columns: new[] { "client_id", "scope" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_client_secrets_client_id",
                table: "ClientSecrets",
                column: "client_id");

            migrationBuilder.CreateIndex(
                name: "ix_identity_providers_scheme",
                table: "IdentityProviders",
                column: "scheme",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_identity_resource_claims_identity_resource_id_type",
                table: "IdentityResourceClaims",
                columns: new[] { "identity_resource_id", "type" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_identity_resource_properties_identity_resource_id_key",
                table: "IdentityResourceProperties",
                columns: new[] { "identity_resource_id", "key" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_identity_resources_name",
                table: "IdentityResources",
                column: "name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApiResourceClaims");

            migrationBuilder.DropTable(
                name: "ApiResourceProperties");

            migrationBuilder.DropTable(
                name: "ApiResourceScopes");

            migrationBuilder.DropTable(
                name: "ApiResourceSecrets");

            migrationBuilder.DropTable(
                name: "ApiScopeClaims");

            migrationBuilder.DropTable(
                name: "ApiScopeProperties");

            migrationBuilder.DropTable(
                name: "ClientClaims");

            migrationBuilder.DropTable(
                name: "ClientCorsOrigins");

            migrationBuilder.DropTable(
                name: "ClientGrantTypes");

            migrationBuilder.DropTable(
                name: "ClientIdPRestrictions");

            migrationBuilder.DropTable(
                name: "ClientPostLogoutRedirectUris");

            migrationBuilder.DropTable(
                name: "ClientProperties");

            migrationBuilder.DropTable(
                name: "ClientRedirectUris");

            migrationBuilder.DropTable(
                name: "ClientScopes");

            migrationBuilder.DropTable(
                name: "ClientSecrets");

            migrationBuilder.DropTable(
                name: "IdentityProviders");

            migrationBuilder.DropTable(
                name: "IdentityResourceClaims");

            migrationBuilder.DropTable(
                name: "IdentityResourceProperties");

            migrationBuilder.DropTable(
                name: "ApiResources");

            migrationBuilder.DropTable(
                name: "ApiScopes");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "IdentityResources");
        }
    }
}
