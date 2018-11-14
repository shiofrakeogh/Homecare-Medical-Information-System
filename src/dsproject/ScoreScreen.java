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
import tictactoegame.TTTWebService;
import tictactoegame.TTTWebService_Service;

/**
 *
 * @author evafinn
 */
public class ScoreScreen extends JPanel {

    public ScoreScreen() {
        TTTWebService_Service link = new TTTWebService_Service();
        TTTWebService proxy = link.getTTTWebServicePort();
        setLayout(new FlowLayout());
        JLabel label = new JLabel("Score");
        add(label);
        
        String[] columnNames = {"Wins", "Losses", "Draws"};
        Object[][] data = {
            {3, 3, 0}
        };
        JTable table = new JTable(data, columnNames);
        JScrollPane scrollPane = new JScrollPane(table);
        add(scrollPane);
    }
}
