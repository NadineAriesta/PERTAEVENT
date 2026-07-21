import sqlite3

def main():
    conn = sqlite3.connect('eventsupport.db')
    cursor = conn.cursor()
    
    event_id = 1
    
    try:
        # Get event name to verify
        cursor.execute("SELECT NamaAcara FROM SupportAcara WHERE IdAcara = ?", (event_id,))
        row = cursor.fetchone()
        if row:
            event_name = row[0]
            print(f"Deleting event '{event_name}' (ID: {event_id})...")
            
            # Delete child requirements
            cursor.execute("DELETE FROM KebutuhanAcara WHERE IdAcara = ?", (event_id,))
            print(f"Deleted associated needs from KebutuhanAcara.")
            
            # Delete any penugasan associated with it
            cursor.execute("DELETE FROM Penugasan WHERE IdAcara = ?", (event_id,))
            print(f"Deleted associated assignments from Penugasan.")
            
            # Delete from RiwayatAcara
            cursor.execute("DELETE FROM RiwayatAcara WHERE IdAcara = ?", (event_id,))
            print(f"Deleted from RiwayatAcara.")
            
            # Delete the event itself
            cursor.execute("DELETE FROM SupportAcara WHERE IdAcara = ?", (event_id,))
            print(f"Deleted event from SupportAcara.")
            
            conn.commit()
            print("SUCCESS: Event deleted successfully!")
        else:
            print(f"Event with ID {event_id} not found in database.")
            
    except Exception as e:
        conn.rollback()
        print("ERROR:", e)
    finally:
        conn.close()

if __name__ == '__main__':
    main()
