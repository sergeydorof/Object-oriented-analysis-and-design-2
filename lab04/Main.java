package org.example;

import javax.swing.*;
import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.SQLException;

//TIP To <b>Run</b> code, press <shortcut actionId="Run"/> or
// click the <icon src="AllIcons.Actions.Execute"/> icon in the gutter.
public class Main {
    public static void main(String[] args) {
        String url = "jdbc:h2:./data/studdb;DB_CLOSE_DELAY=-1";

        try {
            Connection connection = DriverManager.getConnection(url);
            DbInitializer.createTable(connection);

            IStudentMapper mapper = new StudentMapper(connection);

            SwingUtilities.invokeLater(() -> {
                new StudentFrame(mapper).setVisible(true);
            });
        } catch (SQLException e) {
            e.printStackTrace();
        }
    }
}