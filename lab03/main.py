import tkinter as tk
from tkinter import messagebox
from abc import ABC, abstractmethod

# Item
class Song:
    def __init__(self, title, artist):
        self.title = title
        self.artist = artist

# Interface Iterator
class Iterator(ABC):
    @abstractmethod
    def first(self): pass

    @abstractmethod
    def next(self): pass

    @abstractmethod
    def is_done(self) -> bool: pass

    @abstractmethod
    def current_item(self) -> Song: pass

# Interface Aggregate
class Aggregate(ABC):
    @abstractmethod
    def create_iterator(self) -> Iterator: pass

# ConcreteIterator
class MusicIterator(Iterator):
    def __init__(self, aggregate):
        self._aggregate = aggregate
        self._current = 0

    def first(self):
        self._current = 0
        return self.current_item()

    def next(self):
        self._current += 1
        if not self.is_done():
            return self.current_item()
        return None

    def is_done(self) -> bool:
        return self._current >= len(self._aggregate.songs)

    def current_item(self) -> Song:
        if not self.is_done():
            return self._aggregate.songs[self._current]
        return None

# ConcreteAggregate
class PlayList(Aggregate):
    def __init__(self):
        self.songs = []

    def add_song(self, song: Song):
        self.songs.append(song)

    def create_iterator(self) -> Iterator:
        return MusicIterator(self)

# Client
class MusicApp:
    def __init__(self, root, playlist):
        self.playlist = playlist
        self.iterator = self.playlist.create_iterator()

        self.root = root
        self.root.title('Iterator')
        self.root.geometry('400x400')

        # add new song section
        add_frame = tk.LabelFrame(root, text='Add new song', padx=10, pady=10)
        add_frame.pack(fill='x', padx=10, pady=5)

        tk.Label(add_frame, text='Title:').grid(row=0, column=0, sticky='e')
        self.entry_title = tk.Entry(add_frame)
        self.entry_title.grid(row=0, column=1, padx=5, pady=2)

        tk.Label(add_frame, text='Artist:').grid(row=1, column=0, sticky='e')
        self.entry_artist = tk.Entry(add_frame)
        self.entry_artist.grid(row=1, column=1, padx=5, pady=2)

        self.btn_add = tk.Button(add_frame, text='Add to playlist', command=self.add_song)
        self.btn_add.grid(row=2, column=0, columnspan=2, pady=10)

        # iterator section

        play_frame = tk.LabelFrame(root, text='Player', padx=10, pady=10)
        play_frame.pack(fill='both', expand=True, padx=10, pady=5)

        self.label_display = tk.Label(
            text='Playlist is empty',
            wraplength=300,
            font=('Arial', 10, 'italic')
        )

        self.label_display.pack(pady=20)

        btn_nav_frame = tk.Frame(play_frame)
        btn_nav_frame.pack()

        self.label = tk.Label(root, text='Press "Next" to start',
                              wraplength=300, pady=20)
        self.label.pack()

        btn_frame = tk.Frame(root)
        btn_frame.pack(pady=10)

        tk.Button(btn_nav_frame, text='<< First',
                  command=self.go_first).pack(
            side=tk.LEFT, padx=5
        )

        tk.Button(btn_nav_frame, text='Next >>',
                  command=self.go_next).pack(
            side=tk.LEFT, padx=5
        )

    def add_song(self):
        title = self.entry_title.get().strip()
        artist = self.entry_artist.get().strip()

        if title and artist:
            new_song = Song(title, artist)
            self.playlist.add_song(new_song)

            self.entry_artist.delete(0, tk.END)
            self.entry_title.delete(0, tk.END)

            if len(self.playlist.songs) == 1:
                self.iterator = self.playlist.create_iterator()

            messagebox.showinfo('Success', 'Song added')
        else:
            messagebox.showwarning('Error','Enter all fields')

    def go_first(self):
        if not self.playlist.songs:
            self.label_display.config(text='Playlist is empty')
            return

        song = self.iterator.first()
        self.update_ui(song)

    def go_next(self):
        if not self.playlist.songs:
            self.label_display.config(text='Playlist is empty')
            return

        song = self.iterator.next()

        if self.iterator.is_done():
            messagebox.showinfo('End')
            first_song = self.iterator.first()
            self.update_ui(first_song)
        else:
            self.update_ui(song)

    def update_ui(self, song):
        if song:
            self.label_display.config(
                text=f'Now playing:\n{song.artist} - {song.title}'
            )

if __name__ == '__main__':
    my_playlist = PlayList()
    root = tk.Tk()
    app = MusicApp(root, my_playlist)
    root.mainloop()

# реализация без паттерна

# self.playlist = playlist
# self.current_index = 0
#
# def go_next(self):
#     if self.current_index < len(self.playlist.songs) - 1:
#         self.current_index += 1
#         song = self.playlist.songs[self.current_index]
#         self.label.config(text=str(song))
#     else:
#         self.current_index = 0

