#!/usr/bin/env python

'''
% Group 7
% SCT211-0848/2018 - Jany Muong 
% SCT211-0079/2022 - Joram Kireki 
% SCT211-0070/2022 - Vincent Ochieng 
% SCT211-0504/2021 - Gatmach Yuol Nyuon 
% SCT211-0535/2022 - Akech Atem 
% SCT211-0003/2022 - Josphat Waweru Thumi 
'''

import time
import tkinter as tk
from tkinter import ttk, messagebox
from threading import Thread
from collections import defaultdict

class TicTacToe:
    def __init__(self):
        # Initialize empty 3x3 board
        self.board = [[' ' for _ in range(3)] for _ in range(3)]
        self.current_player = 'X'  # X starts
        self.nodes_explored = 0
        self.nodes_explored_ab = 0
        self.move_times = []
        self.move_times_ab = []
        
    def reset_stats(self):
        """Reset performance statistics"""
        self.nodes_explored = 0
        self.nodes_explored_ab = 0
        self.move_times = []
        self.move_times_ab = []
        
    def is_board_full(self):
        """Check if the board is full"""
        for row in self.board:
            if ' ' in row:
                return False
        return True
    
    def is_winner(self, player):
        """Check if the given player has won"""
        # Check rows
        for row in self.board:
            if row.count(player) == 3:
                return True
        
        # Check columns
        for col in range(3):
            if [self.board[row][col] for row in range(3)].count(player) == 3:
                return True
        
        # Check diagonals
        if self.board[0][0] == self.board[1][1] == self.board[2][2] == player:
            return True
        if self.board[0][2] == self.board[1][1] == self.board[2][0] == player:
            return True
        
        return False
    
    def get_empty_cells(self):
        """Return a list of empty cells as (row, col) tuples"""
        empty_cells = []
        for i in range(3):
            for j in range(3):
                if self.board[i][j] == ' ':
                    empty_cells.append((i, j))
        return empty_cells
    
    def make_move(self, row, col, player):
        """Make a move on the board"""
        if self.board[row][col] == ' ':
            self.board[row][col] = player
            return True
        return False
    
    def undo_move(self, row, col):
        """Undo a move on the board"""
        self.board[row][col] = ' '
    
    def get_game_state(self):
        """Return the current state of the game"""
        if self.is_winner('X'):
            return 1  # X wins
        elif self.is_winner('O'):
            return -1  # O wins
        elif self.is_board_full():
            return 0  # Draw
        else:
            return None  # Game still in progress
    
    def minimax(self, depth, is_maximizing):
        """Regular Minimax algorithm implementation"""
        self.nodes_explored += 1
        
        # Check terminal states
        state = self.get_game_state()
        if state is not None:
            return state
        
        if is_maximizing:
            best_score = float('-inf')
            for row, col in self.get_empty_cells():
                self.make_move(row, col, 'X')
                score = self.minimax(depth + 1, False)
                self.undo_move(row, col)
                best_score = max(score, best_score)
            return best_score
        else:
            best_score = float('inf')
            for row, col in self.get_empty_cells():
                self.make_move(row, col, 'O')
                score = self.minimax(depth + 1, True)
                self.undo_move(row, col)
                best_score = min(score, best_score)
            return best_score
    
    def minimax_alpha_beta(self, depth, is_maximizing, alpha, beta):
        """Minimax with Alpha-Beta pruning implementation"""
        self.nodes_explored_ab += 1
        
        # Check terminal states
        state = self.get_game_state()
        if state is not None:
            return state
        
        if is_maximizing:
            best_score = float('-inf')
            for row, col in self.get_empty_cells():
                self.make_move(row, col, 'X')
                score = self.minimax_alpha_beta(depth + 1, False, alpha, beta)
                self.undo_move(row, col)
                best_score = max(score, best_score)
                alpha = max(alpha, best_score)
                if beta <= alpha:
                    break  # Beta cutoff
            return best_score
        else:
            best_score = float('inf')
            for row, col in self.get_empty_cells():
                self.make_move(row, col, 'O')
                score = self.minimax_alpha_beta(depth + 1, True, alpha, beta)
                self.undo_move(row, col)
                best_score = min(score, best_score)
                beta = min(beta, best_score)
                if beta <= alpha:
                    break  # Alpha cutoff
            return best_score
    
    def get_best_move(self, player, use_alpha_beta=False):
        """Get the best move using either regular Minimax or with Alpha-Beta pruning"""
        best_score = float('-inf') if player == 'X' else float('inf')
        best_move = None
        
        for row, col in self.get_empty_cells():
            self.make_move(row, col, player)
            
            if use_alpha_beta:
                if player == 'X':
                    score = self.minimax_alpha_beta(0, False, float('-inf'), float('inf'))
                else:
                    score = self.minimax_alpha_beta(0, True, float('-inf'), float('inf'))
            else:
                if player == 'X':
                    score = self.minimax(0, False)
                else:
                    score = self.minimax(0, True)
            
            self.undo_move(row, col)
            
            if player == 'X':
                if score > best_score:
                    best_score = score
                    best_move = (row, col)
            else:
                if score < best_score:
                    best_score = score
                    best_move = (row, col)
        
        return best_move

class TicTacToeGUI:
    def __init__(self, root):
        self.root = root
        self.root.title("Tic-Tac-Toe AI")
        self.game = TicTacToe()
        self.human_player = 'X'
        self.use_alpha_beta = False
        self.game_mode = None  # 'computer_vs_human' or 'computer_vs_computer'
        self.comparison_results = defaultdict(dict)
        
        # Configure styles
        self.style = ttk.Style()
        self.style.theme_use('clam')  # Modern theme
        
        # Configure colors and fonts
        self.style.configure('TButton', font=('Helvetica', 14), padding=10)
        self.style.configure('Title.TLabel', font=('Helvetica', 24, 'bold'), foreground='#333')
        self.style.configure('Subtitle.TLabel', font=('Helvetica', 16), foreground='#555')
        self.style.configure('Status.TLabel', font=('Helvetica', 12), foreground='#666')
        self.style.configure('Board.TButton', font=('Helvetica', 24), width=3, padding=10)
        self.style.configure('X.TButton', foreground='#3498db')  # Blue for X
        self.style.configure('O.TButton', foreground='#e74c3c')  # Red for O
        self.style.configure('Highlight.TButton', background='#f0f0f0')
        self.style.configure('TFrame', background='#f5f5f5')
        self.style.configure('TLabelFrame', background='#f5f5f5')
        
        # Create main menu
        self.create_main_menu()
    
    def create_main_menu(self):
        """Create the main menu frame"""
        self.clear_window()
        
        # Main container
        main_frame = ttk.Frame(self.root, padding="30")
        main_frame.pack(fill=tk.BOTH, expand=True)
        
        # Title
        title = ttk.Label(main_frame, text="TIC-TAC-TOE AI", style='Title.TLabel')
        title.pack(pady=(0, 20))
        
        # Subtitle
        subtitle = ttk.Label(main_frame, text="Choose Game Mode:", style='Subtitle.TLabel')
        subtitle.pack(pady=(0, 30))
        
        # Button frame
        button_frame = ttk.Frame(main_frame)
        button_frame.pack(fill=tk.X, pady=10)
        
        # Computer vs Human button
        comp_vs_human_btn = ttk.Button(
            button_frame, 
            text="Computer vs Human", 
            command=lambda: self.setup_computer_vs_human(),
            style='TButton'
        )
        comp_vs_human_btn.pack(fill=tk.X, pady=10, ipady=10)
        
        # Computer vs Computer button
        comp_vs_comp_btn = ttk.Button(
            button_frame, 
            text="Computer vs Computer (Compare Algorithms)", 
            command=self.start_computer_vs_computer,
            style='TButton'
        )
        comp_vs_comp_btn.pack(fill=tk.X, pady=10, ipady=10)
        
        # Performance comparison button
        compare_btn = ttk.Button(
            button_frame, 
            text="Performance Comparison", 
            command=self.show_performance_comparison,
            style='TButton'
        )
        compare_btn.pack(fill=tk.X, pady=10, ipady=10)
        
        # Exit button
        exit_btn = ttk.Button(
            button_frame, 
            text="Exit", 
            command=self.root.quit,
            style='TButton'
        )
        exit_btn.pack(fill=tk.X, pady=(20, 0), ipady=10)
    
    def setup_computer_vs_human(self):
        """Setup screen for computer vs human game"""
        self.clear_window()
        self.game_mode = 'computer_vs_human'
        
        # Main container
        main_frame = ttk.Frame(self.root, padding="20")
        main_frame.pack(fill=tk.BOTH, expand=True)
        
        # Title
        title = ttk.Label(main_frame, text="Computer vs Human", style='Title.TLabel')
        title.pack(pady=(0, 20))
        
        # Player selection
        player_frame = ttk.LabelFrame(main_frame, text="Choose Your Side", padding=15)
        player_frame.pack(fill=tk.X, pady=10)
        
        self.player_var = tk.StringVar(value='X')
        ttk.Radiobutton(
            player_frame, text="Play as X (First Player)", 
            variable=self.player_var, value='X',
            style='TRadiobutton'
        ).pack(anchor=tk.W, pady=5)
        ttk.Radiobutton(
            player_frame, text="Play as O (Second Player)", 
            variable=self.player_var, value='O',
            style='TRadiobutton'
        ).pack(anchor=tk.W, pady=5)
        
        # Algorithm selection
        algo_frame = ttk.LabelFrame(main_frame, text="AI Algorithm", padding=15)
        algo_frame.pack(fill=tk.X, pady=10)
        
        self.algo_var = tk.StringVar(value='minimax')
        ttk.Radiobutton(
            algo_frame, text="Use Minimax", 
            variable=self.algo_var, value='minimax',
            style='TRadiobutton'
        ).pack(anchor=tk.W, pady=5)
        ttk.Radiobutton(
            algo_frame, text="Use Alpha-Beta Pruning", 
            variable=self.algo_var, value='alpha_beta',
            style='TRadiobutton'
        ).pack(anchor=tk.W, pady=5)
        
        # Start and back buttons
        button_frame = ttk.Frame(main_frame)
        button_frame.pack(pady=20)
        
        start_btn = ttk.Button(
            button_frame, 
            text="Start Game", 
            command=self.start_computer_vs_human,
            style='TButton'
        )
        start_btn.pack(side=tk.LEFT, padx=10, ipady=5)
        
        back_btn = ttk.Button(
            button_frame, 
            text="Back to Menu", 
            command=self.create_main_menu,
            style='TButton'
        )
        back_btn.pack(side=tk.LEFT, padx=10, ipady=5)
    
    def start_computer_vs_human(self):
        """Start a computer vs human game"""
        self.human_player = self.player_var.get()
        self.use_alpha_beta = self.algo_var.get() == 'alpha_beta'
        self.game = TicTacToe()  # Reset game
        
        self.clear_window()
        self.create_game_board()
        
        # If computer goes first, make its move
        if self.human_player == 'O':
            self.root.after(500, self.computer_move)
    
    def start_computer_vs_computer(self):
        """Start a computer vs computer game (algorithm comparison)"""
        self.game_mode = 'computer_vs_computer'
        self.game = TicTacToe()  # Reset game
        
        self.clear_window()
        self.create_game_board()
        
        # Start the computer vs computer game in a separate thread
        Thread(target=self.run_computer_vs_computer, daemon=True).start()
    
    def run_computer_vs_computer(self):
        """Run the computer vs computer game comparison"""
        # First game with regular Minimax
        self.update_status("Running: Computer (Minimax) vs Computer (Minimax)")
        self.game = TicTacToe()
        self.game.reset_stats()
        result1 = self.play_computer_vs_computer(use_alpha_beta=False)
        
        # Store results
        self.comparison_results['minimax'] = {
            'result': result1,
            'nodes': self.game.nodes_explored,
            'times': self.game.move_times,
            'avg_time': sum(self.game.move_times) / len(self.game.move_times) if self.game.move_times else 0
        }
        
        # Second game with Alpha-Beta
        self.update_status("Running: Computer (Alpha-Beta) vs Computer (Alpha-Beta)")
        self.game = TicTacToe()
        self.game.reset_stats()
        result2 = self.play_computer_vs_computer(use_alpha_beta=True)
        
        # Store results
        self.comparison_results['alpha_beta'] = {
            'result': result2,
            'nodes': self.game.nodes_explored_ab,
            'times': self.game.move_times_ab,
            'avg_time': sum(self.game.move_times_ab) / len(self.game.move_times_ab) if self.game.move_times_ab else 0
        }
        
        # Show comparison results
        self.show_comparison_results()
    
    def update_move(self, row, col, player):
        """Update the GUI board when a move is made"""
        if hasattr(self, 'buttons') and self.buttons[row][col]:
            self.buttons[row][col].config(text=player, style=f'{player}.TButton')
        self.root.update()
    
    def play_computer_vs_computer(self, use_alpha_beta=False):
        """Play a computer vs computer game"""
        while True:
            state = self.game.get_game_state()
            if state is not None:
                return state
            
            # Get the best move for the current player
            start_time = time.time()
            row, col = self.game.get_best_move(self.game.current_player, use_alpha_beta)
            end_time = time.time()
            
            # Record move time
            move_time = end_time - start_time
            if use_alpha_beta:
                self.game.move_times_ab.append(move_time)
            else:
                self.game.move_times.append(move_time)
            
            # Update the GUI
            self.root.after(0, self.update_move, row, col, self.game.current_player)
            self.root.after(0, self.update_status, 
                f"{self.game.current_player} ({'Alpha-Beta' if use_alpha_beta else 'Minimax'}) "
                f"takes position ({row}, {col}) - Time: {move_time:.4f}s"
            )
            
            # Make the move
            self.game.make_move(row, col, self.game.current_player)
            
            # Switch player
            self.game.current_player = 'O' if self.game.current_player == 'X' else 'X'
            
            # Add delay between moves for better visualization
            time.sleep(1)
    
    def show_comparison_results(self):
        """Show the comparison results between algorithms"""
        # Create a new window for results
        results_window = tk.Toplevel(self.root)
        results_window.title("Algorithm Comparison Results")
        results_window.geometry("600x400")
        
        # Main frame
        main_frame = ttk.Frame(results_window, padding="20")
        main_frame.pack(fill=tk.BOTH, expand=True)
        
        # Title
        title = ttk.Label(main_frame, text="Algorithm Performance Comparison", style='Title.TLabel')
        title.pack(pady=(0, 20))
        
        # Results frame
        results_frame = ttk.Frame(main_frame)
        results_frame.pack(fill=tk.BOTH, expand=True)
        
        # Minimax results
        minimax_data = self.comparison_results['minimax']
        ab_data = self.comparison_results['alpha_beta']
        
        # Create comparison table
        columns = ('Metric', 'Minimax', 'Alpha-Beta', 'Improvement')
        tree = ttk.Treeview(results_frame, columns=columns, show='headings', height=5)
        
        # Define headings
        for col in columns:
            tree.heading(col, text=col)
        
        # Add data
        data = [
            ("Nodes Explored", f"{minimax_data['nodes']:,}", f"{ab_data['nodes']:,}", 
             f"{((minimax_data['nodes'] - ab_data['nodes']) / minimax_data['nodes'] * 100):.1f}%"),
            ("Avg Move Time (s)", f"{minimax_data['avg_time']:.4f}", f"{ab_data['avg_time']:.4f}", 
             f"{(minimax_data['avg_time'] - ab_data['avg_time']) / minimax_data['avg_time'] * 100:.1f}%"),
            ("Game Result", 
             "X wins" if minimax_data['result'] == 1 else "O wins" if minimax_data['result'] == -1 else "Draw",
             "X wins" if ab_data['result'] == 1 else "O wins" if ab_data['result'] == -1 else "Draw",
             "-")
        ]
        
        for item in data:
            tree.insert('', tk.END, values=item)
        
        tree.pack(fill=tk.BOTH, expand=True, pady=10)
        
        # Close button
        close_btn = ttk.Button(
            main_frame, 
            text="Close", 
            command=results_window.destroy,
            style='TButton'
        )
        close_btn.pack(pady=10)
    
    def show_performance_comparison(self):
        """Show performance comparison between human and computer play"""
        # Create a new window for results
        compare_window = tk.Toplevel(self.root)
        compare_window.title("Performance Comparison")
        compare_window.geometry("800x600")
        
        # Main frame
        main_frame = ttk.Frame(compare_window, padding="20")
        main_frame.pack(fill=tk.BOTH, expand=True)
        
        # Title
        title = ttk.Label(main_frame, text="Performance Comparison", style='Title.TLabel')
        title.pack(pady=(0, 20))
        
        # Description
        desc = ttk.Label(
            main_frame, 
            text="This comparison shows the difference between human vs computer play\n"
                 "with and without alpha-beta pruning.",
            style='Subtitle.TLabel',
            justify=tk.CENTER
        )
        desc.pack(pady=(0, 30))
        
        # Run tests button
        run_btn = ttk.Button(
            main_frame,
            text="Run Performance Tests",
            command=lambda: self.run_performance_tests(compare_window),
            style='TButton'
        )
        run_btn.pack(pady=20)
        
        # Results frame (will be populated after tests)
        self.results_frame = ttk.Frame(main_frame)
        self.results_frame.pack(fill=tk.BOTH, expand=True)
    
    def run_performance_tests(self, window):
        """Run performance tests and display results"""
        # Disable button during tests
        for widget in window.winfo_children():
            if isinstance(widget, ttk.Button):
                widget.config(state=tk.DISABLED)
        
        # Show loading message
        loading = ttk.Label(self.results_frame, text="Running performance tests...", style='Subtitle.TLabel')
        loading.pack(pady=50)
        window.update()
        
        # Run tests in a separate thread
        Thread(target=lambda: self._run_tests_and_show_results(window, loading), daemon=True).start()
    
    def _run_tests_and_show_results(self, window, loading):
        """Actually run the tests and show results"""
        # Human vs Computer with Minimax
        self.game = TicTacToe()
        self.human_player = 'X'
        self.use_alpha_beta = False
        start_time = time.time()
        self.simulate_human_vs_computer()
        minimax_time = time.time() - start_time
        
        # Human vs Computer with Alpha-Beta
        self.game = TicTacToe()
        self.human_player = 'X'
        self.use_alpha_beta = True
        start_time = time.time()
        self.simulate_human_vs_computer()
        ab_time = time.time() - start_time
        
        # Computer vs Computer with Minimax
        self.game = TicTacToe()
        self.game.reset_stats()
        start_time = time.time()
        self.play_computer_vs_computer(use_alpha_beta=False)
        cc_minimax_time = time.time() - start_time
        cc_minimax_nodes = self.game.nodes_explored
        
        # Computer vs Computer with Alpha-Beta
        self.game = TicTacToe()
        self.game.reset_stats()
        start_time = time.time()
        self.play_computer_vs_computer(use_alpha_beta=True)
        cc_ab_time = time.time() - start_time
        cc_ab_nodes = self.game.nodes_explored_ab
        
        # Update UI with results
        window.after(0, loading.destroy)
        
        # Create results table
        columns = ('Scenario', 'Algorithm', 'Time (s)', 'Nodes Explored', 'Time per Move (s)')
        tree = ttk.Treeview(self.results_frame, columns=columns, show='headings', height=6)
        
        # Define headings
        for col in columns:
            tree.heading(col, text=col)
        
        # dd data
        data = [
            ("Human vs Computer", "Minimax", f"{minimax_time:.2f}", "-", "-"),
            ("Human vs Computer", "Alpha-Beta", f"{ab_time:.2f}", "-", "-"),
            ("", "", "", "", ""),  # Separator
            ("Computer vs Computer", "Minimax", f"{cc_minimax_time:.2f}", f"{cc_minimax_nodes:,}", 
             f"{cc_minimax_time/max(1, len(self.game.move_times)):.4f}"),
            ("Computer vs Computer", "Alpha-Beta", f"{cc_ab_time:.2f}", f"{cc_ab_nodes:,}", 
             f"{cc_ab_time/max(1, len(self.game.move_times_ab)):.4f}"),
            ("", "", "", "", ""),  # Separator
            ("Improvement", "", 
             f"{(minimax_time - ab_time)/minimax_time*100:.1f}% faster (Human)", 
             f"{(cc_minimax_nodes - cc_ab_nodes)/cc_minimax_nodes*100:.1f}% less nodes", 
             f"{(cc_minimax_time/max(1, len(self.game.move_times))) - (cc_ab_time/max(1, len(self.game.move_times_ab))):.4f}s better")
        ]
        
        for item in data:
            tree.insert('', tk.END, values=item)
        
        window.after(0, lambda: tree.pack(fill=tk.BOTH, expand=True, pady=10))
        
        # Re-enable button
        window.after(0, lambda: [w.config(state=tk.NORMAL) for w in window.winfo_children() if isinstance(w, ttk.Button)])
    
    def simulate_human_vs_computer(self):
        """Simulate a human vs computer game for performance testing"""
        self.game = TicTacToe()
        while True:
            state = self.game.get_game_state()
            if state is not None:
                break
            
            if self.game.current_player == self.human_player:
                # Human makes a random valid move (for simulation)
                empty_cells = self.game.get_empty_cells()
                if empty_cells:
                    row, col = empty_cells[0]  # Simple strategy for simulation
                    self.game.make_move(row, col, self.human_player)
            else:
                # Computer makes move
                row, col = self.game.get_best_move(self.game.current_player, self.use_alpha_beta)
                self.game.make_move(row, col, self.game.current_player)
            
            # Switch player
            self.game.current_player = 'O' if self.game.current_player == 'X' else 'X'
    
    def create_game_board(self):
        """Create the game board GUI"""
        # Main container
        main_frame = ttk.Frame(self.root, padding="10")
        main_frame.pack(fill=tk.BOTH, expand=True)
        
        # Status label
        self.status_var = tk.StringVar()
        self.status_var.set(f"Current player: {self.game.current_player}")
        status_label = ttk.Label(
            main_frame, 
            textvariable=self.status_var, 
            style='Status.TLabel'
        )
        status_label.pack(pady=(0, 20))
        
        # Game board
        board_frame = ttk.Frame(main_frame)
        board_frame.pack(pady=10)
        
        self.buttons = [[None for _ in range(3)] for _ in range(3)]
        for i in range(3):
            for j in range(3):
                self.buttons[i][j] = ttk.Button(
                    board_frame,
                    text=' ',
                    style='Board.TButton',
                    command=lambda row=i, col=j: self.on_cell_click(row, col)
                )
                self.buttons[i][j].grid(row=i, column=j, padx=5, pady=5, ipadx=10, ipady=10)
        
        # Control buttons
        control_frame = ttk.Frame(main_frame)
        control_frame.pack(pady=20)
        
        restart_btn = ttk.Button(
            control_frame,
            text="Restart Game",
            command=self.restart_game,
            style='TButton'
        )
        restart_btn.pack(side=tk.LEFT, padx=10, ipady=5)
        
        menu_btn = ttk.Button(
            control_frame,
            text="Main Menu",
            command=self.create_main_menu,
            style='TButton'
        )
        menu_btn.pack(side=tk.LEFT, padx=10, ipady=5)
    
    def on_cell_click(self, row, col):
        """Handle cell click events"""
        if (self.game_mode == 'computer_vs_human' and 
            self.game.current_player == self.human_player and
            self.game.board[row][col] == ' '):
            
            # Human makes move
            self.game.make_move(row, col, self.human_player)
            self.buttons[row][col].config(text=self.human_player, style=f'{self.human_player}.TButton')
            
            # Check game state
            state = self.game.get_game_state()
            if state is not None:
                self.game_over(state)
                return
            
            # Switch to computer's turn
            self.game.current_player = 'O' if self.game.current_player == 'X' else 'X'
            self.update_status(f"Computer is thinking...")
            
            # Computer makes move after a short delay
            self.root.after(500, self.computer_move)
    
    def computer_move(self):
        """Handle computer's move"""
        if self.game_mode != 'computer_vs_human':
            return
            
        start_time = time.time()
        row, col = self.game.get_best_move(
            self.game.current_player, 
            self.use_alpha_beta
        )
        end_time = time.time()
        
        # Make the move
        self.game.make_move(row, col, self.game.current_player)
        self.buttons[row][col].config(text=self.game.current_player, style=f'{self.game.current_player}.TButton')
        
        # Update status
        algo = "Alpha-Beta" if self.use_alpha_beta else "Minimax"
        self.update_status(
            f"Computer ({algo}) chose ({row}, {col}) - "
            f"Time: {end_time - start_time:.4f}s"
        )
        
        # Check game state
        state = self.game.get_game_state()
        if state is not None:
            self.game_over(state)
            return
        
        # Switch back to human's turn
        self.game.current_player = 'O' if self.game.current_player == 'X' else 'X'
        self.update_status(f"Your turn (Player {self.human_player})")
    
    def game_over(self, state):
        """Handle game over state"""
        if state == 1:
            winner = "X"
        elif state == -1:
            winner = "O"
        else:
            winner = None
        
        if winner:
            message = f"Player {winner} wins!"
        else:
            message = "It's a draw!"
        
        messagebox.showinfo("Game Over", message)
        self.update_status(message)
    
    def update_status(self, message):
        """Update the status label"""
        self.status_var.set(message)
    
    def restart_game(self):
        """Restart the current game"""
        self.game = TicTacToe()
        
        # Reset the board
        for i in range(3):
            for j in range(3):
                self.buttons[i][j].config(text=' ', style='Board.TButton')
        
        if self.game_mode == 'computer_vs_human':
            self.update_status(f"Your turn (Player {self.human_player})")
            self.game.current_player = 'X'  # X always starts
            
            # If human is O, computer starts
            if self.human_player == 'O':
                self.root.after(500, self.computer_move)
        else:
            self.update_status("Ready to start computer vs computer game")
            self.start_computer_vs_computer()
    
    def clear_window(self):
        """Clear all widgets from the window"""
        for widget in self.root.winfo_children():
            widget.destroy()

def main():
    root = tk.Tk()
    root.geometry("600x700")
    root.resizable(False, False)
    
    # Set window icon (replace with your icon file if available)
    try:
        root.iconbitmap('tictactoe.ico')
    except:
        pass
    
    app = TicTacToeGUI(root)
    root.mainloop()

if __name__ == "__main__":
    main()