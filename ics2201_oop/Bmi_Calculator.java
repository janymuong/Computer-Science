/*
SCT211-0848/2018
Jany Muong

compile java file in commandline: javac Bmi_Calculator.java
run the compiled program: java Bmi_Calculator
*/
import java.awt.EventQueue;

import javax.swing.JFrame;
import javax.swing.JTextField;
import javax.swing.JLabel;
import javax.swing.JOptionPane;

import java.awt.Font;
import javax.swing.JComboBox;
import javax.swing.JRadioButton;
import javax.swing.ButtonGroup;
import javax.swing.JButton;
import java.awt.event.ActionListener;
import java.text.DecimalFormat;
import java.awt.event.ActionEvent;
import javax.swing.JScrollPane;
import javax.swing.JPanel;


public class Bmi_Calculator {

  private JFrame frame;
  private JTextField textField;
  private JTextField textField_1;
  private JComboBox comboBox;
  private JComboBox comboBox_1;
  private JComboBox comboBox_2;
  String day,year,month;
  String height="",weight="",gen="",result="";
  private ButtonGroup gengp;
  private String dates[]
           = { "1", "2", "3", "4", "5",
               "6", "7", "8", "9", "10",
               "11", "12", "13", "14", "15",
               "16", "17", "18", "19", "20",
               "21", "22", "23", "24", "25",
               "26", "27", "28", "29", "30",
               "31" };
       private String months[]
           = { "Jan", "feb", "Mar", "Apr",
               "May", "Jun", "July", "Aug",
               "Sup", "Oct", "Nov", "Dec" };
       private String years[]
           = { "1995", "1996", "1997", "1998",
               "1999", "2000", "2001", "2002",
               "2003", "2004", "2005", "2006",
               "2007", "2008", "2009", "2010",
               "2011", "2012", "2013", "2014",
               "2015", "2016", "2017", "2018",
               "2019", "2020", "2021", "2022",
               "2023"
              };

  /**
   * Launch the application.
   */
  public static void main(String[] args) {
    EventQueue.invokeLater(new Runnable() {
      public void run() {
        try {
          Bmi_Calculator window = new Bmi_Calculator();
          window.frame.setVisible(true);
        } catch (Exception e) {
          e.printStackTrace();
        }
      }
    });
  }

  /**
   * Create the application.
   */
  public Bmi_Calculator() {
    initialize();
  }

  /**
   * Initialize the contents of the frame.
   */
  private void initialize() {
    frame = new JFrame();
    frame.setBounds(100, 100, 310, 310);
    frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
    frame.getContentPane().setLayout(null);
    
    JLabel lblNewLabel = new JLabel("BMI CALCULATOR");
    lblNewLabel.setBounds(86, 12, 142, 33);
    frame.getContentPane().add(lblNewLabel);
    
    JLabel lblHeight = new JLabel("Height(cm)");
    lblHeight.setBounds(25, 57, 87, 15);
    frame.getContentPane().add(lblHeight);
    
    textField = new JTextField();
    textField.setBounds(113, 57, 87, 19);
    frame.getContentPane().add(textField);
    textField.setColumns(10);
    
    JLabel lblWeight = new JLabel("Weight(Kg)");
    lblWeight.setBounds(25, 96, 87, 15);
    frame.getContentPane().add(lblWeight);
    
    textField_1 = new JTextField();
    textField_1.setColumns(10);
    textField_1.setBounds(113, 94, 87, 19);
    frame.getContentPane().add(textField_1);
    
    JLabel lblGender = new JLabel("Gender");
    lblGender.setBounds(25, 123, 70, 15);
    frame.getContentPane().add(lblGender);
    
    JRadioButton rdbtnMale = new JRadioButton("Male");
    rdbtnMale.addActionListener(new ActionListener() {
      public void actionPerformed(ActionEvent e) {
        gen="Male";
      }
    });
    rdbtnMale.setBounds(25, 139, 70, 23);
    frame.getContentPane().add(rdbtnMale);
    
    JRadioButton rdbtnFemale = new JRadioButton("Female");
    rdbtnFemale.addActionListener(new ActionListener() {
      public void actionPerformed(ActionEvent e) {
        gen="Female";
      }
    });
    rdbtnFemale.setBounds(99, 139, 87, 23);
    frame.getContentPane().add(rdbtnFemale);
    
    JRadioButton rdbtnOther = new JRadioButton("Other");
    rdbtnOther.addActionListener(new ActionListener() {
      public void actionPerformed(ActionEvent e) {
        gen="Other";
      }
    });
    rdbtnOther.setBounds(183, 139, 81, 23);
    frame.getContentPane().add(rdbtnOther);
    gengp = new ButtonGroup();
    gengp.add(rdbtnMale);
    gengp.add(rdbtnFemale);
    gengp.add(rdbtnOther);
    JLabel lblAge = new JLabel("DOB");
    lblAge.setBounds(25, 174, 70, 15);
    frame.getContentPane().add(lblAge);
    
    JButton btnSubmit = new JButton("Submit");
    btnSubmit.addActionListener(new ActionListener() {
      public void actionPerformed(ActionEvent arg0) {
        calculate_bmi();
      }
    });
    btnSubmit.setBounds(20, 215, 92, 25);
    frame.getContentPane().add(btnSubmit);
    
    JButton btnReset = new JButton("Reset");
    btnReset.addActionListener(new ActionListener() {
      public void actionPerformed(ActionEvent e) {
        height="";
        weight="";
        result="";
        day="";
        month="";
        year="";
        gen="";
        textField.setText("");
        textField_1.setText("");
        comboBox.setSelectedIndex(0);
        comboBox_1.setSelectedIndex(0);
        comboBox_2.setSelectedIndex(0);
        rdbtnMale.setSelected(true);
      }
    });
    btnReset.setBounds(172, 215, 92, 25);
    frame.getContentPane().add(btnReset);
    comboBox = new JComboBox(dates);
    comboBox.setBounds(99, 169, 42, 24);
    frame.getContentPane().add(comboBox);
    comboBox_1 = new JComboBox(months);
    comboBox_1.setBounds(139, 169, 47, 24);
    frame.getContentPane().add(comboBox_1);
    comboBox_2 = new JComboBox(years);
    comboBox_2.setBounds(183, 169, 61, 24);
    frame.getContentPane().add(comboBox_2);
  }
  public void calculate_bmi() {
    if(textField.getText().isEmpty() || textField_1.getText().isEmpty() || gen.isEmpty())
      {error();
      return;
      }
    double h,w,r;
    height = textField.getText();
    weight = textField_1.getText();
    day    = dates[comboBox.getSelectedIndex()];
    month    = months[comboBox_1.getSelectedIndex()];
    year    = years[comboBox_2.getSelectedIndex()];
    h=Double.parseDouble(height);
    w=Double.parseDouble(weight);
    r=w/Math.pow((h/100), 2);
    DecimalFormat df = new DecimalFormat("###.##");
    result="";
    result+=String.valueOf(df.format(r));
    if (r >= 25)
     result+="\t Overweight \n You have a higher than normal body weight. \n You could try to exercise more.";
    else if (r > 18.5)
     result+="\t Normal \n You have normal body weight.\n Good Job :)";
    else
      result+="\t Underweight \n You have a lower than normal body weight.\n You could eat a bit more.";
    JFrame f =new JFrame();  
      JOptionPane.showMessageDialog(f,result);      
  }
  public void error() {
    JFrame f =new JFrame();  
      JOptionPane.showMessageDialog(f,"Fill all the details","Alert",JOptionPane.WARNING_MESSAGE);  
  }
}