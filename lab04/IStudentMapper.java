package org.example;

import java.util.List;
import java.util.Optional;

public interface IStudentMapper {
    Optional<Student> findById(int id);
    void insert(Student student);
    void update(Student student);
    void delete(int id);
    List<Student> findAll();
}
