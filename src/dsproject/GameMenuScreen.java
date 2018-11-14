package dsproject;

import java.awt.event.ActionEvent;
import javax.swing.JButton;
import javax.swing.JLabel;
import javax.swing.JPanel;

/**
 *
 * @author evafinn
 */
public class GameMenuScreen extends JPanel {
    public GameMenuScreen(){
//        setLayout(new FlowLayout());
        JLabel label = new JLabel("Ready to play? :)");
        add(label);
    }
}
