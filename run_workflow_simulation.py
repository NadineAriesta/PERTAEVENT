import sqlite3
from datetime import datetime
import time

def print_current_state(cursor, event_id):
    cursor.execute("SELECT NamaAcara, StatusAcara FROM SupportAcara WHERE IdAcara = ?", (event_id,))
    event = cursor.fetchone()
    print(f"   [ACARA] {event[0]} | Status: {event[1]}")
    
    cursor.execute("SELECT IdTeknisi, StatusPenugasan, WaktuKonfirmasi, WaktuUpload, DokumentasiKegiatanFile FROM Penugasan WHERE IdAcara = ?", (event_id,))
    assign = cursor.fetchone()
    if assign:
        print(f"   [PENUGASAN] Teknisi ID {assign[0]} | Status Penugasan: {assign[1]}")
        print(f"      Konfirmasi: {assign[2]} | Upload: {assign[3]}")
        print(f"      File Dokumentasi: {assign[4]}")
    else:
        print("   [PENUGASAN] Belum ada penugasan.")
        
    cursor.execute("SELECT IdTeknisi, StatusKetersediaan FROM MappingTeknisi WHERE IdTeknisi = 1")
    tek = cursor.fetchone()
    print(f"   [TEKNISI] 1 (Joko): Status Ketersediaan = {tek[1]}")
    print("-" * 50)

def main():
    try:
        conn = sqlite3.connect('eventsupport.db')
        cursor = conn.cursor()
    except Exception as e:
        print("ERROR: Tidak dapat membuka database 'eventsupport.db'.")
        print("Periksa apakah berkas database tersebut ada.")
        return
        
    event_id = 1
    
    # Periksa apakah event_id ada di database
    try:
        cursor.execute("SELECT COUNT(*) FROM SupportAcara WHERE IdAcara = ?", (event_id,))
        if cursor.fetchone()[0] == 0:
            print("ERROR: Event dengan ID 1 ('Rapat Pleno Senat Universitas') tidak ditemukan di database.")
            print("Solusi: Silakan hapus file 'eventsupport.db' lalu jalankan (run) proyek .NET Anda kembali agar database di-seed ulang secara otomatis.")
            conn.close()
            return
    except sqlite3.OperationalError:
        print("ERROR: Struktur tabel database belum siap atau table 'SupportAcara' tidak ditemukan.")
        print("Solusi: Silakan jalankan (run) proyek .NET Anda terlebih dahulu agar Entity Framework membuat strukturnya.")
        conn.close()
        return

    # Periksa serta buat penugasan secara otomatis jika belum ada (self-healing)
    cursor.execute("SELECT COUNT(*) FROM Penugasan WHERE IdAcara = ?", (event_id,))
    if cursor.fetchone()[0] == 0:
        print("[INFO] Penugasan untuk Event ID 1 belum ada. Menginisialisasi penugasan otomatis...")
        cursor.execute("UPDATE SupportAcara SET StatusAcara = 'Ditugaskan' WHERE IdAcara = ?", (event_id,))
        cursor.execute("""
            INSERT INTO Penugasan (IdAcara, IdTeknisi, IdUserAdmin, StatusPenugasan, Progress)
            VALUES (?, 1, 1, 'Ditugaskan', 0)
        """, (event_id,))
        cursor.execute("UPDATE MappingTeknisi SET StatusKetersediaan = 'Sibuk' WHERE IdTeknisi = 1")
        now_str = datetime.now().isoformat()
        cursor.execute("""
            INSERT INTO Notifications (IdUser, Message, CreatedAt, Status)
            VALUES (3, 'Penugasan baru untuk Event Rapat Pleno Senat Universitas.', ?, 'Unread')
        """, (now_str,))
        conn.commit()

    print("=" * 60)
    print("SIMULASI INTEGRASI ALUR KERJA (WORKFLOW) PERTAEVENT")
    print("=" * 60)
    
    # 0. Initial State
    print("\n[0] KONDISI AWAL DATABASE:")
    print_current_state(cursor, event_id)
    
    # 1. Step 1: Technician Signs (Dikonfirmasi)
    print("\n[1] MENSIMULASIKAN: TEKNISI JOKO SIGN & KONFIRMASI")
    now_str = datetime.now().isoformat()
    cursor.execute("UPDATE SupportAcara SET StatusAcara = 'Dikonfirmasi' WHERE IdAcara = ?", (event_id,))
    cursor.execute("""
        UPDATE Penugasan 
        SET StatusPenugasan = 'Dikonfirmasi', WaktuKonfirmasi = ? 
        WHERE IdAcara = ?
    """, (now_str, event_id))
    # Send notification to Admin
    cursor.execute("""
        INSERT INTO Notifications (IdUser, Message, CreatedAt, Status)
        VALUES (1, 'Teknisi Joko telah menandatangani konfirmasi untuk Rapat Pleno Senat Universitas.', ?, 'Unread')
    """, (now_str,))
    conn.commit()
    print_current_state(cursor, event_id)
    time.sleep(1)
    
    # 2. Step 2: Technician Uploads Photo
    print("\n[2] MENSIMULASIKAN: TEKNISI JOKO MENGUNGGAH FOTO DOKUMENTASI")
    now_str = datetime.now().isoformat()
    img_path = "/images/id7hJAjeL4_1784257222672.png"
    cursor.execute("UPDATE SupportAcara SET StatusAcara = 'Dokumen Diunggah' WHERE IdAcara = ?", (event_id,))
    cursor.execute("""
        UPDATE Penugasan 
        SET StatusPenugasan = 'Dokumen Diunggah', WaktuUpload = ?, DokumentasiKegiatanFile = ? 
        WHERE IdAcara = ?
    """, (now_str, img_path, event_id))
    # Send notification to Admin
    cursor.execute("""
        INSERT INTO Notifications (IdUser, Message, CreatedAt, Status)
        VALUES (1, 'Teknisi Joko mengunggah foto bukti setup untuk Rapat Pleno Senat Universitas.', ?, 'Unread')
    """, (now_str,))
    conn.commit()
    print_current_state(cursor, event_id)
    time.sleep(1)
    
    # 3. Step 3: Admin Completes Event
    print("\n[3] MENSIMULASIKAN: ADMIN PAK ADIT MENYELESAIKAN ACARA (COMPLETE EVENT)")
    now_str = datetime.now().isoformat()
    
    # Get information for Riwayat
    cursor.execute("SELECT NamaAcara, Tanggal FROM SupportAcara WHERE IdAcara = ?", (event_id,))
    ev_info = cursor.fetchone()
    cursor.execute("SELECT IdPenugasan FROM Penugasan WHERE IdAcara = ?", (event_id,))
    pen_info = cursor.fetchone()
    
    # Insert to RiwayatAcara (Check if already exists to avoid duplicates)
    cursor.execute("SELECT COUNT(*) FROM RiwayatAcara WHERE IdAcara = ?", (event_id,))
    if cursor.fetchone()[0] == 0:
        cursor.execute("""
            INSERT INTO RiwayatAcara (IdAcara, IdPenugasan, NamaAcara, NamaTeknisi, TanggalAcara, DokumentasiKegiatanFile, WaktuSelesai)
            VALUES (?, ?, ?, 'joko', ?, ?, ?)
        """, (event_id, pen_info[0], ev_info[0], ev_info[1], img_path, now_str))
    else:
        cursor.execute("""
            UPDATE RiwayatAcara 
            SET IdPenugasan = ?, NamaAcara = ?, NamaTeknisi = 'joko', TanggalAcara = ?, DokumentasiKegiatanFile = ?, WaktuSelesai = ?
            WHERE IdAcara = ?
        """, (pen_info[0], ev_info[0], ev_info[1], img_path, now_str, event_id))
    
    # Update event status to 'Selesai'
    cursor.execute("UPDATE SupportAcara SET StatusAcara = 'Selesai' WHERE IdAcara = ?", (event_id,))
    
    # Reset Technician status to 'Tersedia'
    cursor.execute("UPDATE MappingTeknisi SET StatusKetersediaan = 'Tersedia' WHERE IdTeknisi = 1")
    
    conn.commit()
    print_current_state(cursor, event_id)
    
    # View history count
    cursor.execute("SELECT COUNT(*) FROM RiwayatAcara")
    print(f"   [RIWAYAT] Jumlah Acara Selesai di RiwayatAcara: {cursor.fetchone()[0]}")
    
    conn.close()
    print("\n[SELESAI] Seluruh alur logika berkesinambungan telah disimulasikan!")

if __name__ == '__main__':
    main()
