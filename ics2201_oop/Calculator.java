import java.awt.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;

import javax.swing.*;

public class Calculator extends JFrame implements ActionListener {

    private JTextField textField;
    private String operator;
    private double firstOperand;

    public Calculator() {
        // Set up the JFrame
        setTitle("Calculator");
        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        setSize(300, 400);
        setLocationRelativeTo(null); // Center the frame on the screen

        // Create components
        textField = new JTextField();
        textField.setEditable(false);

        JPanel buttonPanel = new JPanel(new GridLayout(4, 4));
        String[] buttonLabels = {
                "7", "8", "9", "/",
                "4", "5", "6", "*",
                "1", "2", "3", "-",
                "0", ".", "=", "+"
        };

        for (String label : buttonLabels) {
            JButton button = new JButton(label);
            button.addActionListener(this);
            buttonPanel.add(button);
        }

        // Set up layout
        setLayout(new BorderLayout());
        add(textField, BorderLayout.NORTH);
        add(buttonPanel, BorderLayout.CENTER);
    }

    public void actionPerformed(ActionEvent e) {
        String command = e.getActionCommand();

        switch (command) {
            case "=":
                calculate();
                break;
            case "C":
                clear();
                break;
            default:
                updateTextField(command);
                break;
        }
    }

    private void calculate() {
        double result = 0;
        double secondOperand = Double.parseDouble(textField.getText());

        switch (operator) {
            case "+":
                result = firstOperand + secondOperand;
                break;
            case "-":
                result = firstOperand - secondOperand;
                break;
            case "*":
                result = firstOperand * secondOperand;
                break;
            case "/":
                if (secondOperand != 0) {
                    result = firstOperand / secondOperand;
                } else {
                    JOptionPane.showMessageDialog(this, "Cannot divide by zero", "Error", JOptionPane.ERROR_MESSAGE);
                    clear();
                    return;
                }
                break;
        }

        textField.setText(Double.toString(result));
        operator = null;
    }

    private void clear() {
        textField.setText("");
        operator = null;
    }

    private void updateTextField(String text) {
        if (text.matches("[0-9.]")) {
            textField.setText(textField.getText() + text);
        } else if (text.matches("[+\\-*/]")) {
            if (operator == null) {
                firstOperand = Double.parseDouble(textField.getText());
                operator = text;
                textField.setText("");
            } else {
                calculate(); // Calculate with the previous operator before changing it
                operator = text;
            }
        }
    }

    public static void main(String[] args) {
        SwingUtilities.invokeLater(() -> {
            Calculator calculator = new Calculator();
            calculator.setVisible(true);
        });
    }
}
