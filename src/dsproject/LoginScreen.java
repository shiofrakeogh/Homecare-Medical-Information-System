/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package dsproject;

import java.awt.BorderLayout;
import java.awt.FlowLayout;
import java.awt.GridLayout;
import java.awt.event.ActionEvent;
import javax.swing.JButton;
import javax.swing.JFrame;
import javax.swing.JLabel;
import javax.swing.JPanel;
import javax.swing.JPasswordField;
import javax.swing.JTextField;
import tictactoegame.TTTWebService;
import tictactoegame.TTTWebService_Service;

/**
 *
 * @author evafinn
 */
public class LoginScreen extends JPanel {
    JTextField username, password;
    public LoginScreen() {
        TTTWebService_Service link = new TTTWebService_Service();
        TTTWebService proxy = link.getTTTWebServicePort();
        setLayout(new FlowLayout());
        JLabel usernameLabel, passwordLabel;
        usernameLabel = new JLabel("Username:");
        passwordLabel = new JLabel("Password:");
        username = new JTextField(20);
        password = new JPasswordField(20);

        this.add(usernameLabel);
        this.add(username);
        this.add(passwordLabel);
        this.add(password);
    }
 
    public String getUsername(){
        return username.getText();
    }
    public String getPassword(){
        return password.getText();
    }
    
    public void clearTextFields(){
        username.setText("");
        password.setText("");
    }
}
