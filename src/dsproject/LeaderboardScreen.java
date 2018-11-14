/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package dsproject;

import java.awt.FlowLayout;
import java.awt.event.ActionEvent;
import javax.swing.JButton;
import javax.swing.JFrame;
import javax.swing.JLabel;
import javax.swing.JPanel;
import javax.swing.JScrollPane;
import javax.swing.JTable;

/**
 *
 * @author evafinn
 */
public class LeaderboardScreen extends JPanel {
    public LeaderboardScreen(){
        setLayout(new FlowLayout());
        JLabel label = new JLabel("Leaderboard");
        add(label);
       
        String[] columnNames = {"Users","Wins", "Losses", "Draws"};
        Object[][] data = {
            {"User1" , 3, 3, 0},
            {"User2" , 0, 7, 2},
            {"User3" , 10, 0, 0},
            {"User4" , 2, 3, 9},
            {"User5" , 7, 1, 15}
        };
        JTable table = new JTable(data, columnNames);
        JScrollPane scrollPane = new JScrollPane(table);  
        add(scrollPane);
    }
}
