package dsproject;

import java.awt.FlowLayout;
import java.awt.GridLayout;
import java.awt.event.ActionEvent;
import javax.swing.JButton;
import javax.swing.JFrame;
import javax.swing.JLabel;
import javax.swing.JOptionPane;
import javax.swing.JPanel;
import javax.swing.SwingConstants;

/**
 *
 * @author evafinn
 */
public class WelcomeScreen extends JPanel {

    public WelcomeScreen() {
//        setLayout(new FlowLayout());
        JLabel welcomeLabel = new JLabel();
        welcomeLabel.setBounds(100, 410, 200, 200);
        welcomeLabel.setText("Welcome to TicTacToe");

        add(welcomeLabel);
    }
}
