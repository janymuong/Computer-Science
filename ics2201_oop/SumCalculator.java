import javax.swing.*;
import java.awt.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;

public class SumCalculator extends JFrame {
    private JTextField numField1, numField2;
    private JButton addButton;
    private JLabel resultLabel;

    public SumCalculator() {
        // Set up the frame
        setTitle("Sum Calculator");
        setSize(300, 150);
        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        setLocationRelativeTo(null);

        // Create components
        numField1 = new JTextField(10);
        numField2 = new JTextField(10);
        addButton = new JButton("Calculate Sum");
        resultLabel = new JLabel("Result: ");

        // Set layout manager
        setLayout(new GridLayout(4, 1));

        // Add components to the frame
        add(new JLabel("Enter Number 1:"));
        add(numField1);
        add(new JLabel("Enter Number 2:"));
        add(numField2);
        add(addButton);
        add(resultLabel);

        // Add action listener to the button
        addButton.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                calculateSum();
            }
        });
    }

    private void calculateSum() {
        try {
            // Get values from text fields
            int num1 = Integer.parseInt(numField1.getText());
            int num2 = Integer.parseInt(numField2.getText());

            // Calculate sum
            int sum = num1 + num2;

            // Display the result
            resultLabel.setText("Result: " + sum);
        } catch (NumberFormatException ex) {
            // Handle non-integer input
            resultLabel.setText("Invalid input. Please enter valid integers.");
        }
    }

    public static void main(String[] args) {
        SwingUtilities.invokeLater(new Runnable() {
            @Override
            public void run() {
                new SumCalculator().setVisible(true);
            }
        });
    }
}
