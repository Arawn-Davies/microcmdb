using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace microcmdb.Web.Migrations
{
    /// <inheritdoc />
    public partial class ngSchemaMigr : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CINodeMapping_ConfigItem_ConfigItemID",
                table: "CINodeMapping");

            migrationBuilder.DropForeignKey(
                name: "FK_CINodeMapping_Node_NodeID",
                table: "CINodeMapping");

            migrationBuilder.DropForeignKey(
                name: "FK_HostServiceMapping_Host_HostID",
                table: "HostServiceMapping");

            migrationBuilder.DropForeignKey(
                name: "FK_HostServiceMapping_Service_ServiceID",
                table: "HostServiceMapping");

            migrationBuilder.DropForeignKey(
                name: "FK_NetworkUserMapping_NetworkUser_NetworkUserID",
                table: "NetworkUserMapping");

            migrationBuilder.DropForeignKey(
                name: "FK_NetworkUserMapping_Node_NodeID",
                table: "NetworkUserMapping");

            migrationBuilder.DropForeignKey(
                name: "FK_Node_ConfigItem_ConfigItemID",
                table: "Node");

            migrationBuilder.DropForeignKey(
                name: "FK_NodeHostMapping_Host_HostID",
                table: "NodeHostMapping");

            migrationBuilder.DropForeignKey(
                name: "FK_NodeHostMapping_Node_NodeID",
                table: "NodeHostMapping");

            migrationBuilder.DropForeignKey(
                name: "FK_SoftwareInstallation_Node_NodeID",
                table: "SoftwareInstallation");

            migrationBuilder.DropForeignKey(
                name: "FK_SoftwareInstallation_Software_SoftwareID",
                table: "SoftwareInstallation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SoftwareInstallation",
                table: "SoftwareInstallation");

            migrationBuilder.DropIndex(
                name: "IX_SoftwareInstallation_NodeID",
                table: "SoftwareInstallation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Service",
                table: "Service");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NodeHostMapping",
                table: "NodeHostMapping");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Node",
                table: "Node");

            migrationBuilder.DropIndex(
                name: "IX_Node_ConfigItemID",
                table: "Node");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NetworkUserMapping",
                table: "NetworkUserMapping");

            migrationBuilder.DropIndex(
                name: "IX_NetworkUserMapping_NodeID",
                table: "NetworkUserMapping");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NetworkUser",
                table: "NetworkUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HostServiceMapping",
                table: "HostServiceMapping");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Host",
                table: "Host");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ConfigItem",
                table: "ConfigItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CINodeMapping",
                table: "CINodeMapping");

            migrationBuilder.DropIndex(
                name: "IX_CINodeMapping_NodeID",
                table: "CINodeMapping");

            migrationBuilder.DropColumn(
                name: "ConfigItemID",
                table: "Node");

            migrationBuilder.RenameTable(
                name: "SoftwareInstallation",
                newName: "SoftwareInstallations");

            migrationBuilder.RenameTable(
                name: "Service",
                newName: "Services");

            migrationBuilder.RenameTable(
                name: "NodeHostMapping",
                newName: "NodeHostMappings");

            migrationBuilder.RenameTable(
                name: "Node",
                newName: "Nodes");

            migrationBuilder.RenameTable(
                name: "NetworkUserMapping",
                newName: "UserMappings");

            migrationBuilder.RenameTable(
                name: "NetworkUser",
                newName: "NetworkUsers");

            migrationBuilder.RenameTable(
                name: "HostServiceMapping",
                newName: "HostServiceMappings");

            migrationBuilder.RenameTable(
                name: "Host",
                newName: "Hosts");

            migrationBuilder.RenameTable(
                name: "ConfigItem",
                newName: "ConfigItems");

            migrationBuilder.RenameTable(
                name: "CINodeMapping",
                newName: "CINodeMappings");

            migrationBuilder.RenameIndex(
                name: "IX_NodeHostMapping_NodeID",
                table: "NodeHostMappings",
                newName: "IX_NodeHostMappings_NodeID");

            migrationBuilder.RenameIndex(
                name: "IX_NodeHostMapping_HostID",
                table: "NodeHostMappings",
                newName: "IX_NodeHostMappings_HostID");

            migrationBuilder.RenameIndex(
                name: "IX_HostServiceMapping_ServiceID",
                table: "HostServiceMappings",
                newName: "IX_HostServiceMappings_ServiceID");

            migrationBuilder.RenameIndex(
                name: "IX_CINodeMapping_ConfigItemID",
                table: "CINodeMappings",
                newName: "IX_CINodeMappings_ConfigItemID");

            migrationBuilder.AlterColumn<int>(
                name: "NodeHostMappingID",
                table: "NodeHostMappings",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AlterColumn<int>(
                name: "CINodeMappingID",
                table: "CINodeMappings",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SoftwareInstallations",
                table: "SoftwareInstallations",
                columns: new[] { "NodeID", "SoftwareID" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Services",
                table: "Services",
                column: "ServiceID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NodeHostMappings",
                table: "NodeHostMappings",
                column: "NodeHostMappingID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Nodes",
                table: "Nodes",
                column: "NodeID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserMappings",
                table: "UserMappings",
                columns: new[] { "NodeID", "NetworkUserID" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_NetworkUsers",
                table: "NetworkUsers",
                column: "NetworkUserID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HostServiceMappings",
                table: "HostServiceMappings",
                columns: new[] { "HostID", "ServiceID" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Hosts",
                table: "Hosts",
                column: "HostID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ConfigItems",
                table: "ConfigItems",
                column: "ConfigItemID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CINodeMappings",
                table: "CINodeMappings",
                column: "CINodeMappingID");

            migrationBuilder.CreateIndex(
                name: "IX_SoftwareInstallations_SoftwareID",
                table: "SoftwareInstallations",
                column: "SoftwareID");

            migrationBuilder.CreateIndex(
                name: "IX_UserMappings_NetworkUserID",
                table: "UserMappings",
                column: "NetworkUserID");

            migrationBuilder.CreateIndex(
                name: "IX_CINodeMappings_NodeID",
                table: "CINodeMappings",
                column: "NodeID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CINodeMappings_ConfigItems_ConfigItemID",
                table: "CINodeMappings",
                column: "ConfigItemID",
                principalTable: "ConfigItems",
                principalColumn: "ConfigItemID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CINodeMappings_Nodes_NodeID",
                table: "CINodeMappings",
                column: "NodeID",
                principalTable: "Nodes",
                principalColumn: "NodeID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HostServiceMappings_Hosts_HostID",
                table: "HostServiceMappings",
                column: "HostID",
                principalTable: "Hosts",
                principalColumn: "HostID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HostServiceMappings_Services_ServiceID",
                table: "HostServiceMappings",
                column: "ServiceID",
                principalTable: "Services",
                principalColumn: "ServiceID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NodeHostMappings_Hosts_HostID",
                table: "NodeHostMappings",
                column: "HostID",
                principalTable: "Hosts",
                principalColumn: "HostID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NodeHostMappings_Nodes_NodeID",
                table: "NodeHostMappings",
                column: "NodeID",
                principalTable: "Nodes",
                principalColumn: "NodeID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SoftwareInstallations_Nodes_NodeID",
                table: "SoftwareInstallations",
                column: "NodeID",
                principalTable: "Nodes",
                principalColumn: "NodeID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SoftwareInstallations_Software_SoftwareID",
                table: "SoftwareInstallations",
                column: "SoftwareID",
                principalTable: "Software",
                principalColumn: "SoftwareID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserMappings_NetworkUsers_NetworkUserID",
                table: "UserMappings",
                column: "NetworkUserID",
                principalTable: "NetworkUsers",
                principalColumn: "NetworkUserID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserMappings_Nodes_NodeID",
                table: "UserMappings",
                column: "NodeID",
                principalTable: "Nodes",
                principalColumn: "NodeID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CINodeMappings_ConfigItems_ConfigItemID",
                table: "CINodeMappings");

            migrationBuilder.DropForeignKey(
                name: "FK_CINodeMappings_Nodes_NodeID",
                table: "CINodeMappings");

            migrationBuilder.DropForeignKey(
                name: "FK_HostServiceMappings_Hosts_HostID",
                table: "HostServiceMappings");

            migrationBuilder.DropForeignKey(
                name: "FK_HostServiceMappings_Services_ServiceID",
                table: "HostServiceMappings");

            migrationBuilder.DropForeignKey(
                name: "FK_NodeHostMappings_Hosts_HostID",
                table: "NodeHostMappings");

            migrationBuilder.DropForeignKey(
                name: "FK_NodeHostMappings_Nodes_NodeID",
                table: "NodeHostMappings");

            migrationBuilder.DropForeignKey(
                name: "FK_SoftwareInstallations_Nodes_NodeID",
                table: "SoftwareInstallations");

            migrationBuilder.DropForeignKey(
                name: "FK_SoftwareInstallations_Software_SoftwareID",
                table: "SoftwareInstallations");

            migrationBuilder.DropForeignKey(
                name: "FK_UserMappings_NetworkUsers_NetworkUserID",
                table: "UserMappings");

            migrationBuilder.DropForeignKey(
                name: "FK_UserMappings_Nodes_NodeID",
                table: "UserMappings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserMappings",
                table: "UserMappings");

            migrationBuilder.DropIndex(
                name: "IX_UserMappings_NetworkUserID",
                table: "UserMappings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SoftwareInstallations",
                table: "SoftwareInstallations");

            migrationBuilder.DropIndex(
                name: "IX_SoftwareInstallations_SoftwareID",
                table: "SoftwareInstallations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Services",
                table: "Services");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Nodes",
                table: "Nodes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NodeHostMappings",
                table: "NodeHostMappings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NetworkUsers",
                table: "NetworkUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HostServiceMappings",
                table: "HostServiceMappings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Hosts",
                table: "Hosts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ConfigItems",
                table: "ConfigItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CINodeMappings",
                table: "CINodeMappings");

            migrationBuilder.DropIndex(
                name: "IX_CINodeMappings_NodeID",
                table: "CINodeMappings");

            migrationBuilder.RenameTable(
                name: "UserMappings",
                newName: "NetworkUserMapping");

            migrationBuilder.RenameTable(
                name: "SoftwareInstallations",
                newName: "SoftwareInstallation");

            migrationBuilder.RenameTable(
                name: "Services",
                newName: "Service");

            migrationBuilder.RenameTable(
                name: "Nodes",
                newName: "Node");

            migrationBuilder.RenameTable(
                name: "NodeHostMappings",
                newName: "NodeHostMapping");

            migrationBuilder.RenameTable(
                name: "NetworkUsers",
                newName: "NetworkUser");

            migrationBuilder.RenameTable(
                name: "HostServiceMappings",
                newName: "HostServiceMapping");

            migrationBuilder.RenameTable(
                name: "Hosts",
                newName: "Host");

            migrationBuilder.RenameTable(
                name: "ConfigItems",
                newName: "ConfigItem");

            migrationBuilder.RenameTable(
                name: "CINodeMappings",
                newName: "CINodeMapping");

            migrationBuilder.RenameIndex(
                name: "IX_NodeHostMappings_NodeID",
                table: "NodeHostMapping",
                newName: "IX_NodeHostMapping_NodeID");

            migrationBuilder.RenameIndex(
                name: "IX_NodeHostMappings_HostID",
                table: "NodeHostMapping",
                newName: "IX_NodeHostMapping_HostID");

            migrationBuilder.RenameIndex(
                name: "IX_HostServiceMappings_ServiceID",
                table: "HostServiceMapping",
                newName: "IX_HostServiceMapping_ServiceID");

            migrationBuilder.RenameIndex(
                name: "IX_CINodeMappings_ConfigItemID",
                table: "CINodeMapping",
                newName: "IX_CINodeMapping_ConfigItemID");

            migrationBuilder.AddColumn<int>(
                name: "ConfigItemID",
                table: "Node",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "NodeHostMappingID",
                table: "NodeHostMapping",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AlterColumn<int>(
                name: "CINodeMappingID",
                table: "CINodeMapping",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_NetworkUserMapping",
                table: "NetworkUserMapping",
                columns: new[] { "NetworkUserID", "NodeID" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_SoftwareInstallation",
                table: "SoftwareInstallation",
                columns: new[] { "SoftwareID", "NodeID" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Service",
                table: "Service",
                column: "ServiceID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Node",
                table: "Node",
                column: "NodeID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NodeHostMapping",
                table: "NodeHostMapping",
                columns: new[] { "NodeID", "HostID" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_NetworkUser",
                table: "NetworkUser",
                column: "NetworkUserID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HostServiceMapping",
                table: "HostServiceMapping",
                columns: new[] { "HostID", "ServiceID" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Host",
                table: "Host",
                column: "HostID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ConfigItem",
                table: "ConfigItem",
                column: "ConfigItemID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CINodeMapping",
                table: "CINodeMapping",
                columns: new[] { "ConfigItemID", "NodeID" });

            migrationBuilder.CreateIndex(
                name: "IX_NetworkUserMapping_NodeID",
                table: "NetworkUserMapping",
                column: "NodeID");

            migrationBuilder.CreateIndex(
                name: "IX_SoftwareInstallation_NodeID",
                table: "SoftwareInstallation",
                column: "NodeID");

            migrationBuilder.CreateIndex(
                name: "IX_Node_ConfigItemID",
                table: "Node",
                column: "ConfigItemID");

            migrationBuilder.CreateIndex(
                name: "IX_CINodeMapping_NodeID",
                table: "CINodeMapping",
                column: "NodeID");

            migrationBuilder.AddForeignKey(
                name: "FK_CINodeMapping_ConfigItem_ConfigItemID",
                table: "CINodeMapping",
                column: "ConfigItemID",
                principalTable: "ConfigItem",
                principalColumn: "ConfigItemID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CINodeMapping_Node_NodeID",
                table: "CINodeMapping",
                column: "NodeID",
                principalTable: "Node",
                principalColumn: "NodeID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HostServiceMapping_Host_HostID",
                table: "HostServiceMapping",
                column: "HostID",
                principalTable: "Host",
                principalColumn: "HostID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HostServiceMapping_Service_ServiceID",
                table: "HostServiceMapping",
                column: "ServiceID",
                principalTable: "Service",
                principalColumn: "ServiceID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NetworkUserMapping_NetworkUser_NetworkUserID",
                table: "NetworkUserMapping",
                column: "NetworkUserID",
                principalTable: "NetworkUser",
                principalColumn: "NetworkUserID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NetworkUserMapping_Node_NodeID",
                table: "NetworkUserMapping",
                column: "NodeID",
                principalTable: "Node",
                principalColumn: "NodeID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Node_ConfigItem_ConfigItemID",
                table: "Node",
                column: "ConfigItemID",
                principalTable: "ConfigItem",
                principalColumn: "ConfigItemID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NodeHostMapping_Host_HostID",
                table: "NodeHostMapping",
                column: "HostID",
                principalTable: "Host",
                principalColumn: "HostID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NodeHostMapping_Node_NodeID",
                table: "NodeHostMapping",
                column: "NodeID",
                principalTable: "Node",
                principalColumn: "NodeID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SoftwareInstallation_Node_NodeID",
                table: "SoftwareInstallation",
                column: "NodeID",
                principalTable: "Node",
                principalColumn: "NodeID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SoftwareInstallation_Software_SoftwareID",
                table: "SoftwareInstallation",
                column: "SoftwareID",
                principalTable: "Software",
                principalColumn: "SoftwareID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
