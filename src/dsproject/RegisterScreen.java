/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package dsproject;

import java.awt.FlowLayout;
import javax.swing.JLabel;
import javax.swing.JPanel;
import javax.swing.JTextField;
/**
 *
 * @author evafinn
 */
public class RegisterScreen extends JPanel {
    JLabel firstnameL, surnameL, usernameL, passwordL;
    JTextField firstname, surname, username, password;

    public RegisterScreen() {
        setLayout(new FlowLayout());
        firstnameL = new JLabel("First name:");
        firstname = new JTextField(20);

        surnameL = new JLabel("Surname:");
        surname = new JTextField(20);

        usernameL = new JLabel("Username:");
        username = new JTextField(20);

        passwordL = new JLabel("Password");
        password = new JTextField(20);

        add(firstnameL);
        add(firstname);
        add(surnameL);
        add(surname);
        add(usernameL);
        add(username);
        add(passwordL);
        add(password);
    }
    
    public String getFirstname(){
        return firstname.getText();
    }
    public String getSurname(){
        return surname.getText();
    }
    public String getUsername(){
        return username.getText();
    }
    public String getPassword(){
        return password.getText();
    }
    
    public void clearTextFields(){
        firstname.setText("");
        surname.setText("");
        username.setText("");
        password.setText("");
    }
}
