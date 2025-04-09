#include <stdio.h>
#include <arpa/inet.h>

int main() {
    uint16_t host_short = 0x1234;
    uint32_t host_long = 0x12345678;

    // Convert to network byte order
    uint16_t net_short = htons(host_short);
    uint32_t net_long = htonl(host_long);

    printf("Host Short: 0x%x, Network Short: 0x%x\n", host_short, net_short);
    printf("Host Long: 0x%x, Network Long: 0x%x\n", host_long, net_long);

    // Convert back to host byte order
    printf("Converted Back - Short: 0x%x, Long: 0x%x\n",
           ntohs(net_short), ntohl(net_long));

    return (0);
}

