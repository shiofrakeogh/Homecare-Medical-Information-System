/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package dsproject;

import java.awt.CardLayout;
import java.awt.event.ActionEvent;
import javax.swing.JButton;
import javax.swing.JOptionPane;
import javax.swing.JPanel;
import tictactoegame.TTTWebService;
import tictactoegame.TTTWebService_Service;

/**
 *
 * @author evafinn
 */
public class Panel extends JPanel {

    WelcomeScreen welcomescreen;
    LoginScreen loginscreen;
    RegisterScreen registerscreen;
    GameMenuScreen gamemenuscreen;
    GameScreen gamescreen;
    LeaderboardScreen leaderboardscreen;
    ScoreScreen scorescreen;

    public Panel() {
        TTTWebService_Service link = new TTTWebService_Service();
        TTTWebService port = link.getTTTWebServicePort();
        
        welcomescreen = new WelcomeScreen();
        loginscreen = new LoginScreen();
        registerscreen = new RegisterScreen();
        gamemenuscreen = new GameMenuScreen();
        gamescreen = new GameScreen();
        leaderboardscreen = new LeaderboardScreen();
        scorescreen = new ScoreScreen();

        this.setLayout(new CardLayout());
        this.add(welcomescreen, "WELCOME");
        this.add(loginscreen, "LOGIN");
        this.add(registerscreen, "REGISTER");
        this.add(gamemenuscreen, "MENU");
        this.add(gamescreen, "GAME");
        this.add(leaderboardscreen, "LEADERBOARD");
        this.add(scorescreen, "SCORES");

        JButton loginBtnWS = new JButton("Login");
        loginBtnWS.addActionListener((ActionEvent e) -> {
            this.changeCard("LOGIN");
        });
        JButton registerBtnWS = new JButton("Register");
        registerBtnWS.addActionListener((ActionEvent e) -> {
            this.changeCard("REGISTER");
        });
        welcomescreen.add(loginBtnWS);
        welcomescreen.add(registerBtnWS);

        JButton loginBtnLS = new JButton("Login");
        loginBtnLS.addActionListener((ActionEvent e) -> {
            if(port.login(loginscreen.getUsername(), loginscreen.getPassword()) == -1){
               JOptionPane.showMessageDialog(this, "Wrong Credentials", "Error", JOptionPane.ERROR_MESSAGE);
               loginscreen.clearTextFields();
            } 
            else if(loginscreen.getPassword().equals("") || loginscreen.getUsername().equals(""))
            {
                JOptionPane.showMessageDialog(this, "Text Fields are blank..", "Error", JOptionPane.ERROR_MESSAGE);
            }
            else {
                this.changeCard("MENU");
                System.out.println("USER ID IS: " + port.login(loginscreen.getUsername(), loginscreen.getPassword()));
            }
        });
        loginscreen.add(loginBtnLS);

       
        JButton registerBtnRS = new JButton("Register User");
        registerBtnRS.addActionListener((ActionEvent e) -> {
            if(registerscreen.getUsername().equals("") || registerscreen.getPassword().equals("") || registerscreen.getFirstname().equals("") || registerscreen.getSurname().equals(""))
            {
                JOptionPane.showMessageDialog(this, "Text Fields are blank..", "Error", JOptionPane.ERROR_MESSAGE);
            }
            else{
                String result = port.register(registerscreen.getUsername(), registerscreen.getPassword(), registerscreen.getFirstname(), registerscreen.getSurname());
                switch(result) {
            case "ERROR-INSERT" :
                JOptionPane.showMessageDialog(null, "couldn’t add the data to the users table", "Error", JOptionPane.ERROR_MESSAGE); 
                registerscreen.clearTextFields();
                break;
            case "ERROR-RETRIEVE" :
                JOptionPane.showMessageDialog(null, "cannot retrieve the newly inserted data from the users table", "Error", JOptionPane.ERROR_MESSAGE);
                registerscreen.clearTextFields();
                break;
            case "ERROR-DB" :
                JOptionPane.showMessageDialog(null, "cannot find the database", "Error", JOptionPane.ERROR_MESSAGE); 
                registerscreen.clearTextFields();
                break;
            case "ERROR-REPEAT" :
                JOptionPane.showMessageDialog(null, "a user with that username already exists", "Error", JOptionPane.ERROR_MESSAGE); 
                registerscreen.clearTextFields();
                break;
            default :
                this.changeCard("LOGIN");
                }
            }
        });
        registerscreen.add(registerBtnRS);
        
        JButton scoreBtn = new JButton("Scores");
        JButton leaderboardBtn = new JButton("Leaderboard");
        JButton newGameBtn = new JButton("New Game");
        scoreBtn.addActionListener((ActionEvent e) -> {
            this.changeCard("SCORES");
        });
        leaderboardBtn.addActionListener((ActionEvent e) -> {
            this.changeCard("LEADERBOARD");
        });
        newGameBtn.addActionListener((ActionEvent e) -> {
            this.changeCard("GAME");
        });
        gamemenuscreen.add(scoreBtn);
        gamemenuscreen.add(leaderboardBtn);
        gamemenuscreen.add(newGameBtn);
        
        JButton backBtn = new JButton("Back");
        backBtn.addActionListener((ActionEvent e) -> {
            this.changeCard("MENU");
        });
        gamescreen.add(backBtn);
        
        JButton backBtn1 = new JButton("Back");
        backBtn1.addActionListener((ActionEvent e) -> {
            this.changeCard("MENU");
        });
        scorescreen.add(backBtn1);
        
        JButton backBtn2 = new JButton("Back");
        backBtn2.addActionListener((ActionEvent e) -> {
            this.changeCard("MENU");
        });
        leaderboardscreen.add(backBtn2);
    }

    public void changeCard(String cardName) {
        if (cardName.equals("LOBBY")) {
//			//if the card is lobby update the list and user
//			lobbyPanel.updateGameList();
//			lobbyPanel.updateUserLabel(currentUser);
        } else if (cardName.equals("GAME")) {
            //if the card is game start the timer
//			gamePanel.startCheck();
        }
        //change to the card with the key passed in
        CardLayout cl = (CardLayout) (this.getLayout());
        cl.show(this, cardName);
    }
}
