package org.example;

import javax.swing.*;
import javax.swing.table.DefaultTableModel;
import java.awt.*;
import java.util.List;

public class StudentFrame extends JFrame {
    private final IStudentMapper mapper;

    private JTable table;
    private DefaultTableModel tableModel;

    private JTextField txtId = new JTextField(5);
    private JTextField txtName = new JTextField(15);
    private JTextField txtEmail = new JTextField(15);

    public StudentFrame(IStudentMapper mapper) {
        this.mapper = mapper;
        setTitle("Управление студентами (Data Mapper + Swing)");
        setSize(600, 400);
        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        setLocationRelativeTo(null);

        String[] columns = {"ID", "Имя", "Email"};
        tableModel = new DefaultTableModel(columns, 0);
        table = new JTable(tableModel);
        refreshTable();

        JPanel inputPanel = new JPanel(new GridLayout(3, 2, 5, 5));
        inputPanel.add(new JLabel("ID:"));
        inputPanel.add(txtId);
        inputPanel.add(new JLabel("Имя:"));
        inputPanel.add(txtName);
        inputPanel.add(new JLabel("Email:"));
        inputPanel.add(txtEmail);

        JButton btnAdd = new JButton("Добавить");
        JButton btnUpdate = new JButton("Обновить");
        JButton btnDelete = new JButton("Удалить");

        JPanel buttonPanel = new JPanel();
        buttonPanel.add(btnAdd);
        buttonPanel.add(btnUpdate);
        buttonPanel.add(btnDelete);

        btnAdd.addActionListener(e -> {
            Student s = new Student(
                    Integer.parseInt(txtId.getText()),
                    txtName.getText(),
                    txtEmail.getText()
            );
            mapper.insert(s);
            refreshTable();
            clearFields();
        });

        btnUpdate.addActionListener(e -> {
            Student s = new Student(
                    Integer.parseInt(txtId.getText()),
                    txtName.getText(),
                    txtEmail.getText()
            );
            mapper.update(s);
            refreshTable();
        });

        btnDelete.addActionListener(e -> {
            int id = Integer.parseInt(txtId.getText());
            mapper.delete(id);
            refreshTable();
            clearFields();
        });

        table.getSelectionModel().addListSelectionListener(e -> {
            if (!e.getValueIsAdjusting() && table.getSelectedRow() != -1) {
                int row = table.getSelectedRow();
                txtId.setText(tableModel.getValueAt(row, 0).toString());
                txtName.setText(tableModel.getValueAt(row, 1).toString());
                txtEmail.setText(tableModel.getValueAt(row, 2).toString());
            }
        });

        JPanel topPanel = new JPanel(new BorderLayout());
        topPanel.add(inputPanel, BorderLayout.CENTER);
        topPanel.add(buttonPanel, BorderLayout.SOUTH);

        add(new JScrollPane(table), BorderLayout.CENTER);
        add(topPanel, BorderLayout.NORTH);
    }

    private void refreshTable() {
        tableModel.setRowCount(0);
        List<Student> students = mapper.findAll();

        for (Student s: students) {
            tableModel.addRow(new Object[] {s.getId(), s.getName(), s.getEmail()});
        }
    }

    private void clearFields() {
        txtId.setText("");
        txtName.setText("");
        txtEmail.setText("");
    }
}
