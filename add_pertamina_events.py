import sqlite3
from datetime import datetime, timedelta

def main():
    conn = sqlite3.connect('eventsupport.db')
    cursor = conn.cursor()
    
    try:
        # Date strings
        tomorrow = (datetime.now() + timedelta(days=1)).strftime("%Y-%m-%d")
        day_after = (datetime.now() + timedelta(days=2)).strftime("%Y-%m-%d")
        
        # Event 1
        cursor.execute("""
            INSERT INTO SupportAcara (IdUserHelpdesk, NamaAcara, Tanggal, JamMulai, JamSelesai, Lokasi, StatusAcara)
            VALUES (?, ?, ?, ?, ?, ?, ?)
        """, (2, "Townhall Pertamina: Strategi Digitalisasi SPBU 2026", tomorrow, "09:00:00", "12:00:00", "Executive Lounge Lt. 21 Kantor Pusat Pertamina", "Belum Ditugaskan"))
        
        event_1_id = cursor.lastrowid
        
        # Event 1 Needs
        cursor.execute("""
            INSERT INTO KebutuhanAcara (IdAcara, JenisKebutuhan, Jumlah, Keterangan)
            VALUES (?, 'Proyektor', 1, 'Layar videotron utama')
        """, (event_1_id,))
        cursor.execute("""
            INSERT INTO KebutuhanAcara (IdAcara, JenisKebutuhan, Jumlah, Keterangan)
            VALUES (?, 'Sound System', 1, 'Mic wireless & audio console')
        """, (event_1_id,))
        
        # Event 2
        cursor.execute("""
            INSERT INTO SupportAcara (IdUserHelpdesk, NamaAcara, Tanggal, JamMulai, JamSelesai, Lokasi, StatusAcara)
            VALUES (?, ?, ?, ?, ?, ?, ?)
        """, (2, "Sosialisasi Aplikasi MyPertamina Enterprise", day_after, "13:30:00", "16:00:00", "Auditorium Lt. 3 Gedung Pertamina Hulu Energi", "Belum Ditugaskan"))
        
        event_2_id = cursor.lastrowid
        
        # Event 2 Needs
        cursor.execute("""
            INSERT INTO KebutuhanAcara (IdAcara, JenisKebutuhan, Jumlah, Keterangan)
            VALUES (?, 'Sound System', 1, 'Speaker 4 unit & mic clip-on')
        """, (event_2_id,))
        cursor.execute("""
            INSERT INTO KebutuhanAcara (IdAcara, JenisKebutuhan, Jumlah, Keterangan)
            VALUES (?, 'Layar / Screen', 2, 'Layar monitor preview untuk narasumber')
        """, (event_2_id,))
        
        conn.commit()
        print("SUCCESS: Pertamina events added successfully!")
        
    except Exception as e:
        conn.rollback()
        print("ERROR:", e)
    finally:
        conn.close()

if __name__ == '__main__':
    main()
