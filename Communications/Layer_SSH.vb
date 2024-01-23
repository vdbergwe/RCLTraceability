Imports System.Data.Entity
Imports Intranet.Meta_Devices
Imports Microsoft.SqlServer
Imports System.IO
Imports System.Web.Script.Serialization
Imports Renci.SshNet
Imports Microsoft.Ajax.Utilities
Imports System.Net.Mail

Namespace Communications
    Public Class Layer_SSH
        Private Shared db As New OMD_DatawarehouseEntities
        Private Shared userName As String = db.Software_Settings.Find("e1adaa13-bbea-466a-846b-206230177176").SettingValue
        Private Shared password As String = db.Software_Settings.Find("4924605d-9995-48ef-a287-be8510c95613").SettingValue
        Private Shared BASE_URL As String = db.Software_Settings.Find("ee15e4ec-face-409b-a4a0-92b90dd0b58b").SettingValue
        Private Shared DEV_MODE As String = db.Software_Settings.Find("7988522e-3922-4b4a-acbd-71293a816e19").SettingValue
        Private Shared REGISTRATION_URL As String = db.Software_Settings.Find("94d647dc-dc16-4d30-9610-3e817e824091").SettingValue
        Private Shared CONFIGURATION_ENDPOINTS_URL As String = db.Software_Settings.Find("37b3fe99-ef0a-4b8f-9f9c-d0bdced20a40").SettingValue
        Private Shared StorageLocation As String = "C:\IntranetProduction"
        Private Shared device As New Device
        Public Shared Function Get_CPU_Temp(device As Device) As String
            'vcgencmd measure_temp
            Dim SSHClient As New SshClient(host:=device.IP, username:=userName, password:=password)
            If device.Type = "Sartorius Scale Connector" Then
                userName = "pi"
                password = "raspberry"
            End If
            SSHClient.Connect()
            Try
                Dim update = SSHClient.RunCommand("vcgencmd measure_temp")
                Dim result = update.Result()
                Return result
            Catch ex As Exception
                SSHClient.Disconnect()
            End Try
            SSHClient.Disconnect()
            Return ""
        End Function
        'SSH Sudo Reboot System                                                 DONE FE v4
        Public Shared Function Reboot_Device(device As Device) As String
            Dim SSHClient As New SshClient(host:=device.IP, username:=userName, password:=password)
            If device.Type = "Sartorius Scale Connector" Then
                userName = "pi"
                password = "raspberry"
            End If
            SSHClient.Connect()
            Try
                SSHClient.RunCommand("sudo reboot")
            Catch ex As Exception
                SSHClient.Disconnect()
            End Try
            Return "Reboot Success"
        End Function
        'SSH Sudo apt Update                                                    DONE FE v4
        Public Shared Function Device_Update_Repos(device As Device) As String
            Dim SSHClient As New SshClient(host:=device.IP, username:=userName, password:=password)
            If device.Type = "Sartorius Scale Connector" Then
                userName = "pi"
                password = "raspberry"
            End If
            SSHClient.Connect()
            Dim result As String = SSHClient.RunCommand("sudo apt update && sudo apt install --assume-yes").Result.ToString
            SSHClient.Disconnect()
            Return result
        End Function
        Public Shared Function Device_Install_7z(device As Device) As String
            Dim SSHClient As New SshClient(host:=device.IP, username:=userName, password:=password)
            If device.Type = "Sartorius Scale Connector" Then
                userName = "pi"
                password = "raspberry"
            End If
            SSHClient.Connect()
            Dim result As String = SSHClient.RunCommand("sudo apt update && sudo apt install --assume-yes p7zip-full").Result.ToString()
            SSHClient.Disconnect()
            Return result
        End Function
        Public Shared Function Device_Install_Python(device As Device) As String
            Dim SSHClient As New SshClient(host:=device.IP, username:=userName, password:=password)
            If device.Type = "Sartorius Scale Connector" Then
                userName = "pi"
                password = "raspberry"
            End If
            SSHClient.Connect()
            Dim result As String = SSHClient.RunCommand("sudo apt install python3-tk").Result.ToString()
            SSHClient.Disconnect()
            Return result
        End Function
        Public Shared Function Device_Install_Pip(device As Device) As String
            Dim SSHClient As New SshClient(host:=device.IP, username:=userName, password:=password)
            If device.Type = "Sartorius Scale Connector" Then
                userName = "pi"
                password = "raspberry"
            End If
            SSHClient.Connect()
            SSHClient.RunCommand("sudo python3 -m pip install --upgrade pip")
            SSHClient.Disconnect()
            Return "Pip Installed and Updated Succesfully Rebooting Device"
        End Function
        Public Shared Function Device_Install_Pillow(device As Device) As String
            Dim SSHClient As New SshClient(host:=device.IP, username:=userName, password:=password)
            If device.Type = "Sartorius Scale Connector" Then
                userName = "pi"
                password = "raspberry"
            End If
            SSHClient.Connect()
            SSHClient.RunCommand("sudo python3 -m pip install --upgrade Pillow")
            SSHClient.Disconnect()
            Return "Pillow Installed and Updated Succesfully Rebooting Device"
        End Function
        Public Shared Function Device_Install_Julian(device As Device) As String
            Dim SSHClient As New SshClient(host:=device.IP, username:=userName, password:=password)
            If device.Type = "Sartorius Scale Connector" Then
                userName = "pi"
                password = "raspberry"
            End If
            SSHClient.Connect()
            SSHClient.RunCommand("sudo python3 -m pip install --upgrade julian")
            SSHClient.Disconnect()
            Return "Julian Installed and Updated Succesfully Rebooting Device"
        End Function
        Public Shared Function Device_Install_Zebra(device As Device) As String
            Dim SSHClient As New SshClient(host:=device.IP, username:=userName, password:=password)
            If device.Type = "Sartorius Scale Connector" Then
                userName = "pi"
                password = "raspberry"
            End If
            SSHClient.Connect()
            SSHClient.RunCommand("sudo python3 -m pip install --upgrade zebra")
            SSHClient.Disconnect()
            Return "Zebra Installed and Updated Succesfully Rebooting Device"
        End Function
        Public Shared Function Device_Install_GuiZero(device As Device) As String
            Dim SSHClient As New SshClient(host:=device.IP, username:=userName, password:=password)
            If device.Type = "Sartorius Scale Connector" Then
                userName = "pi"
                password = "raspberry"
            End If
            SSHClient.Connect()
            SSHClient.RunCommand("sudo python3 -m pip install --upgrade guizero")
            SSHClient.Disconnect()
            Return "Pillow Installed and Updated Succesfully Rebooting Device"
            Reboot_Device(device)
        End Function
        Public Shared Function Device_Install_Labelary(device As Device) As String
            Dim SSHClient As New SshClient(host:=device.IP, username:=userName, password:=password)
            If device.Type = "Sartorius Scale Connector" Then
                userName = "pi"
                password = "raspberry"
            End If
            SSHClient.Connect()
            SSHClient.RunCommand("sudo python3 -m pip install --upgrade labelary-mwisslead")
            SSHClient.Disconnect()
            Return "Labelary Installed and Updated Succesfully Rebooting Device"
            Reboot_Device(device)
        End Function
        Public Shared Function Device_Set_HostName(device As Device) As String
            Dim SSHClient As New SshClient(host:=device.IP, username:=userName, password:=password)
            If device.Type = "Sartorius Scale Connector" Then
                userName = "pi"
                password = "raspberry"
            End If
            SSHClient.Connect()
            SSHClient.RunCommand("sudo hostname " + device.Description.ToLower())
            SSHClient.Disconnect()
            Return "Hostname Changed"
        End Function
        Public Shared Function Device_Create_Directories(device As Device) As String
            Dim SSHClient As New SshClient(host:=device.IP, username:=userName, password:=password)
            Dim Sftp As New SftpClient(host:=device.IP, username:=userName, password:=password)
            SSHClient.Connect()
            If device.Type = "Sartorius Scale Connector" Then
                userName = "pi"
                password = "raspberry"
            End If
            If device.Type = "Traceability Waypoint" Then
                Dim FileMeta = db.Software_Packages.Single(Function(s) s.Status = "Current" And s.Type = "Waypoint Software")
                Dim FilePath = StorageLocation + FileMeta.PackageLocation.Replace("/", "\")
                SSHClient.RunCommand("mkdir logs")
                SSHClient.RunCommand("mkdir /home/omegadata/Backups")
                SSHClient.RunCommand("mkdir /home/omegadata/SoftwarePackages")
                SSHClient.RunCommand("mkdir /home/omegadata/SoftwarePackages/Traceability/")
                SSHClient.RunCommand("mkdir /home/omegadata/SoftwarePackages/Traceability/" + FileMeta.Version)
                SSHClient.RunCommand("mkdir /home/omegadata/SoftwarePackages/Traceability/" + FileMeta.Version)
                Sftp.Connect()
            End If
            Return "Operating Strucure Created"
            Reboot_Device(device)
        End Function
        Public Shared Function Device_Backup_Software(device As Device) As String
            Dim SSHClient As New SshClient(host:=device.IP, username:=userName, password:=password)
            Dim Sftp As New SftpClient(host:=device.IP, username:=userName, password:=password)
            If device.Type = "Sartorius Scale Connector" Then
                userName = "pi"
                password = "raspberry"
            End If
            If device.Type = "Traceability Waypoint" Then
                Dim FileMeta = db.Software_Packages.Single(Function(s) s.Status = "Current" And s.Type = "Waypoint Software")
                Dim FilePath = StorageLocation + FileMeta.PackageLocation.Replace("/", "\")
                SSHClient.Connect()
                SSHClient.RunCommand("mkdir /home/omegadata/Backups/Traceability/")
                SSHClient.RunCommand("7z a " & "/home/omegadata/Backups/Traceability/" & Now.ToFileTime.ToString() & ".7z /home/omegadata/Backups/Traceability/" & Now.ToFileTime.ToString() & "/")
                SSHClient.Disconnect()
            End If
            Return "Successfully Backup Software on Remote"
        End Function
        Public Shared Function Device_Decompress_Software(device As Device) As String
            Device_Backup_Software(device)
            Dim SSHClient As New SshClient(host:=device.IP, username:=userName, password:=password)
            Dim Sftp As New SftpClient(host:=device.IP, username:=userName, password:=password)
            SSHClient.Connect()
            If device.Type = "Sartorius Scale Connector" Then
                userName = "pi"
                password = "raspberry"
            End If
            If device.Type = "Traceability Waypoint" Then
                Dim FileMeta = db.Software_Packages.Single(Function(s) s.Status = "Current" And s.Type = "Waypoint Software")
                Dim FilePath = StorageLocation + FileMeta.PackageLocation.Replace("/", "\")
                Sftp.Connect()
                Dim fs As FileStream = New FileStream(FilePath, FileMode.Open)
                Using fs
                    Sftp.BufferSize = 4 * 1024
                    Sftp.UploadFile(fs, "/home/omegadata" + FileMeta.PackageLocation)
                End Using
                SSHClient.RunCommand("7z x /home/omegadata" + FileMeta.PackageLocation + " -aoa")
                SSHClient.RunCommand("sudo rm /home/omegadata/Traceability/storage/configs/machine_config.json")
                Dim MachineConfig As New machine_Config With {
                    .BASE_URL = BASE_URL,
                    .REGISTRATION_URL = REGISTRATION_URL,
                    .CONFIGURATION_ENDPOINTS_URL = CONFIGURATION_ENDPOINTS_URL,
                    .DEVICE_ID = device.Id,
                    .DEV_MODE = DEV_MODE,
                    .COUNTRY = device.Waypoint1.Plants_Locations.Business_Units_Plants.Country
                    }
                Dim inputJson = (New JavaScriptSerializer()).Serialize(MachineConfig)
                Sftp.WriteAllText("/home/omegadata/Traceability/storage/configs/machine_config.json", inputJson)
                Sftp.Disconnect()
            End If
            Return "Successfully Installed Software on Remote"
        End Function
        Public Shared Function Device_Software_Lock(device As Device) As String
            Dim SSHClient As New SshClient(host:=device.IP, username:=userName, password:=password)
            SSHClient.Connect()
            Try
                SSHClient.RunCommand("cd && cd ~/.config && mkdir lxsession")
                SSHClient.RunCommand("cd && cd ~/.config/lxsession && mkdir LXDE-pi")
                SSHClient.RunCommand("cd && cd Traceability && chmod 755 launcher.sh")
                SSHClient.RunCommand("cd && cd Traceability && mv /home/omegadata/Traceability/autostart ~/.config/lxsession/LXDE-pi/autostart")
            Catch ex As Exception
                SSHClient.Disconnect()
            End Try
            SshClient.Disconnect()
            Return "Successfully Installed Software on Remote"
            Reboot_Device(device)
        End Function
        'SSH Sudo Get System Information                                        DONE FE v4
        Public Shared Function Update_Device_Software(device As Device) As String
            If device.Type = "Sartorius Scale Connector" Then
                userName = "pi"
                password = "raspberry"
            End If
            Try
                Device_Backup_Software(device)
                Device_Update_Repos(device)
                Device_Install_Python(device)
                Device_Install_Pip(device)
                Device_Install_7z(device)
                Device_Install_GuiZero(device)
                Device_Install_Julian(device)
                Device_Install_Labelary(device)
                Device_Install_Pillow(device)
                Device_Install_Zebra(device)
                Device_Set_HostName(device)
                Get_SystemInfo(device)
            Catch ex As Exception

            End Try
            Return "Update Succes"
            Reboot_Device(device)
        End Function
        'SSH Sudo Get System Information                                        DONE FE v4
        Public Shared Function Get_SystemInfo(device As Device)
            Dim SSHClient As New SshClient(host:=device.IP, username:=userName, password:=password)
            If device.Type = "Sartorius Scale Connector" Then
                userName = "pi"
                password = "raspberry"
            End If
            Try
                SSHClient.Connect()
                Dim update = SSHClient.RunCommand("sudo cat /proc/cpuinfo")
                Dim result = update.Result()
                device = Get_NetworkInfo(device)
                device.HardwareVersion = result
                db.Entry(device).State = EntityState.Modified
                db.SaveChanges()
            Catch ex As Exception

            End Try
            Return device
        End Function
        'SSH Sudo Get Network Information                                       DONE FE v4
        Public Shared Function Get_NetworkInfo(device As Device)
            Dim SSHClient As New SshClient(host:=device.IP, username:=userName, password:=password)
            If device.Type = "Sartorius Scale Connector" Then
                userName = "pi"
                password = "raspberry"
            End If
            SSHClient.Connect()
            Dim update = SSHClient.RunCommand("sudo ifconfig -s eth0")
            Dim result = update.Result()
            device.NetworkInformation = result
            db.Entry(device).State = EntityState.Modified
            db.SaveChanges()
            'cat /sys/class/net/ens1f0/address
            update = SSHClient.RunCommand("sudo ifconfig eth0 | grep ether | awk '{print $2}'")
            result = update.Result()
            device.MAC = result.Trim()
            Return device
        End Function
        'SSH Sudo Send File                                                     DONE FE v4
        Public Shared Function Send_Software(device As Device) As String
            Dim SSHClient As New SshClient(host:=device.IP, username:=userName, password:=password)
            Dim Sftp As New SftpClient(host:=device.IP, username:=userName, password:=password)
            SSHClient.Connect()
            If device.Type = "Sartorius Scale Connector" Then
                userName = "pi"
                password = "raspberry"
            End If
            If device.Type = "Sartorius Scale Connector" Then
                Dim File = db.Software_Packages.Single(Function(s) s.Status = "Current" And s.Type = "Scales Software")
                If SSHClient.IsConnected = False Then
                    SSHClient.Connect()
                End If
                Dim update = SSHClient.RunCommand("mkdir /home/pi/SoftwarePackages")
                update = SSHClient.RunCommand("mkdir /home/pi/SoftwarePackages/Scales/")
                update = SSHClient.RunCommand("mkdir /home/pi/SoftwarePackages/Scales/" + File.Version)
                Dim FilePath = VirtualPathUtility.ToAppRelative(File.PackageLocation)
                Sftp.Connect()
                Dim fs As FileStream = New FileStream(FilePath, FileMode.Open)
                Using fs
                    Sftp.BufferSize = 4 * 1024
                    Sftp.UploadFile(fs, "/home/pi" + File.PackageLocation)
                End Using
                update = SSHClient.RunCommand("sudo apt update && sudo apt install --assume-yes p7zip-full")
                update = SSHClient.RunCommand("mkdir /home/pi/Backups")
                update = SSHClient.RunCommand("mkdir ~/.config/lxsession/LXDE-pi")
                update = SSHClient.RunCommand("cd && sudo mv /home/pi/Scales /home/pi/Backups/Scales")
                update = SSHClient.RunCommand("7z x /home/pi" + File.PackageLocation + " -aoa")
                SSHClient.RunCommand("sudo rm /home/pi/Scales/storage/configs/machine_config.json")
                Dim MachineConfig As New machine_Config With {
                    .BASE_URL = "https://pretorius-home.myddns.me:44344/",
                    .REGISTRATION_URL = "/Devices/Device_Registration/?Id=",
                    .CONFIGURATION_ENDPOINTS_URL = "/Devices/Device_Endpoints/?Id=",
                    .DEVICE_ID = device.Id,
                    .DEV_MODE = "False",
                    .COUNTRY = device.Waypoint1.Plants_Locations.Business_Units_Plants.Country
                    }
                Dim inputJson = (New JavaScriptSerializer()).Serialize(MachineConfig)
                Sftp.WriteAllText("/home/pi/Scales/storage/configs/machine_config.json", inputJson)
                Sftp.Disconnect()
                SSHClient.Disconnect()
            End If
            Return "Success"
        End Function

    End Class

End Namespace
