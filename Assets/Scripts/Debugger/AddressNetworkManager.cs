using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using TMPro;

public class AddressNetworkManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _ipText;
    private List<string> _ipList = new List<string>();
    [SerializeField] private TextMeshProUGUI _ipPrefab;
    [SerializeField] private Transform _ipContainer;
    void Start()
    {
        string ipAddress = GetLocalIPAddress();
        Debug.Log("IP Address: " + ipAddress);
        _ipText.text = ipAddress;
    }

    string GetLocalIPAddress() 
    {
        string ipAddress = "";
        try
        {
            // Get the local machine's IP addresses
            IPAddress[] localIPs = Dns.GetHostAddresses(Dns.GetHostName());
            
            // Iterate through the IP addresses and find the IPv4 address
            foreach (IPAddress ip in localIPs)
            {
                TextMeshProUGUI newIpTextPrefab = Instantiate(_ipPrefab, _ipContainer, true);
                newIpTextPrefab.text = ip.ToString();
                
                if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    ipAddress = ip.ToString();
                    break;
                }
            }
        }
        catch (System.Exception ex)
        {
            Debug.LogError("Failed to get IP address: " + ex.Message);
        }
        return ipAddress;
    }
}
