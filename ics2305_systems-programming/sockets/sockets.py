import socket

# Create a socket
server_socket = socket.socket(socket.AF_INET, socket.SOCK_STREAM)

# Bind to a specific address and port
server_address = ('localhost', 65432)  # Use any free port
server_socket.bind(server_address)

# Listen for incoming connections
server_socket.listen(1)
print("Echo server is running...")

while True:
    # Accept a new connection
    client_socket, client_address = server_socket.accept()
    print(f"Connection established with {client_address}")

    while True:
        # Receive data from the client
        data = client_socket.recv(1024)
        if not data:
            break  # Connection closed by the client
        print(f"Received: {data.decode()}")
        
        # Send the same data back (echo)
        client_socket.sendall(data)

    client_socket.close()
    print(f"Connection with {client_address} closed.")

