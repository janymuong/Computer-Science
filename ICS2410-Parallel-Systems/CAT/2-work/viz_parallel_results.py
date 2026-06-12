import plotly.graph_objects as go
from plotly.subplots import make_subplots

# Your data
data = {
    "Sequential C": {100: 0.000075, 500: 0.001459, 1000: 0.004422},
    "Sequential Python": {100: 0.000866, 500: 0.024065, 1000: 0.083200},
}

openmp_static = {
    100: {2: 0.000096, 4: 0.000182, 8: 0.002848},
    500: {2: 0.000578, 4: 0.000364, 8: 0.003042},
    1000: {2: 0.002254, 4: 0.001969, 8: 0.001474},
}

openmp_dynamic = {
    100: {2: 0.003063, 4: 0.000198, 8: 0.000149},
    500: {2: 0.003356, 4: 0.000412, 8: 0.000346},
    1000: {2: 0.002808, 4: 0.001888, 8: 0.001490},
}

mp_python = {
    100: {2: 0.131119, 4: 0.019177, 8: 0.025650},
    500: {2: 0.062516, 4: 0.062232, 8: 0.068581},
    1000: {2: 0.195113, 4: 0.198525, 8: 0.188988},
}

# Compute speedups
def compute_speedups(parallel_times, seq_times):
    speedups = {}
    for size in parallel_times:
        speedups[size] = {}
        for threads in parallel_times[size]:
            speedups[size][threads] = seq_times[size] / parallel_times[size][threads]
    return speedups

openmp_static_speedup = compute_speedups(openmp_static, data["Sequential C"])
openmp_dynamic_speedup = compute_speedups(openmp_dynamic, data["Sequential C"])
mp_speedup = compute_speedups(mp_python, data["Sequential Python"])

# Create subplots: 2 rows, 2 columns
fig = make_subplots(
    rows=2, cols=2,
    subplot_titles=("Execution Time (log scale)", "Speedup vs Threads (Size 1000)",
                    "OpenMP Static vs Dynamic (Size 1000)", "Python MP Overhead (Size 1000)"),
    vertical_spacing=0.15
)

# ---- Plot 1: Execution time for all models (size 1000) ----
sizes = [100, 500, 1000]
best_omp = {s: min(openmp_static[s].values()) for s in sizes}
fig.add_trace(go.Scatter(x=sizes, y=[data["Sequential C"][s] for s in sizes], mode='lines+markers', name="Seq C"), row=1, col=1)
fig.add_trace(go.Scatter(x=sizes, y=[data["Sequential Python"][s] for s in sizes], mode='lines+markers', name="Seq Python"), row=1, col=1)
fig.add_trace(go.Scatter(x=sizes, y=[best_omp[s] for s in sizes], mode='lines+markers', name="OpenMP (best)"), row=1, col=1)
fig.add_trace(go.Scatter(x=sizes, y=[mp_python[s][2] for s in sizes], mode='lines+markers', name="MP Python (2 proc)"), row=1, col=1)
fig.update_yaxes(type="log", title="Time (seconds)", row=1, col=1)
fig.update_xaxes(title="Matrix Size", row=1, col=1)

# ---- Plot 2: Speedup vs threads for size 1000 ----
threads_list = [2,4,8]
fig.add_trace(go.Scatter(x=threads_list, y=[openmp_static_speedup[1000][t] for t in threads_list], mode='lines+markers', name="OMP static"), row=1, col=2)
fig.add_trace(go.Scatter(x=threads_list, y=[openmp_dynamic_speedup[1000][t] for t in threads_list], mode='lines+markers', name="OMP dynamic"), row=1, col=2)
fig.add_trace(go.Scatter(x=threads_list, y=[mp_speedup[1000][t] for t in threads_list], mode='lines+markers', name="Python MP"), row=1, col=2)
fig.add_hline(y=1, line_dash="dash", line_color="gray", row=1, col=2)
fig.update_yaxes(title="Speedup (relative to sequential)", row=1, col=2)
fig.update_xaxes(title="Threads / Processes", row=1, col=2)

# ---- Plot 3: OpenMP static vs dynamic comparison (size 1000) ----
fig.add_trace(go.Bar(x=[f"{t} thr" for t in threads_list], y=[openmp_static[1000][t] for t in threads_list], name="Static"), row=2, col=1)
fig.add_trace(go.Bar(x=[f"{t} thr" for t in threads_list], y=[openmp_dynamic[1000][t] for t in threads_list], name="Dynamic"), row=2, col=1)
fig.update_yaxes(title="Time (seconds)", row=2, col=1)
fig.update_xaxes(title="Threads", row=2, col=1)

# ---- Plot 4: Python MP overhead (size 1000) ----
fig.add_trace(go.Scatter(x=threads_list, y=[mp_python[1000][t] for t in threads_list], mode='lines+markers', name="MP Python", line=dict(color='red')), row=2, col=2)
fig.add_hline(y=data["Sequential Python"][1000], line_dash="dot", line_color="green", annotation_text="Seq Python", row=2, col=2)
fig.update_yaxes(title="Time (seconds)", row=2, col=2)
fig.update_xaxes(title="Processes", row=2, col=2)

fig.update_layout(title="Parallel Programming Models Comparison", height=800, showlegend=True)
fig.write_html("parallel_benchmark_dashboard.html")
print("✅ Dashboard saved as 'parallel_benchmark_dashboard.html'")